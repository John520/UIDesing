using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIDesing.dataSql.config;
namespace UIDesing.dataSql.data
{
    public class MyContext : DbContext
    {
        //static string connectionString = "server=localhost;port=3306;database=dbtest;uid=root;password=123456789";
        public MyContext()
            : base("name=MyContext")
        {
            Database.SetInitializer<MyContext>(new CreateDatabaseIfNotExists<MyContext>());
            Database.SetInitializer<MyContext>(new DropCreateDatabaseIfModelChanges<MyContext>());

        }
        // Constructor to use on a DbConnection that is already opened
        public MyContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new fileConfig());
            modelBuilder.Configurations.Add(new cateConfig());
            modelBuilder.Configurations.Add(new feedConfig());
            modelBuilder.Configurations.Add(new PCBConfig());
            modelBuilder.Configurations.Add(new plugConfig());
            modelBuilder.Configurations.Add(new markConfig());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<File_data> Files { get; set; }
        public DbSet<PCB_data> PCBs { get; set; }
        public DbSet<Mark_data> Marks { get; set; }
        public DbSet<Cate_data> Cates { get; set; }
        public DbSet<Plug_data> Plugs { get; set; }
        public DbSet<Feed_data> Feeds { get; set; }
        /// <summary>
        /// 用于保存或更新对象。
        /// 如果要查询files
        /// </summary>
        /// <param name="fileId">文件名</param>
        /// <param name="obj2">要保存的对象</param>
        /// <returns>返回保存的对象id</returns>
        public int save(int fileId, object obj)
        {
            int ret = -1;
            if (obj.GetType() == typeof(File_data))
            {
                //返回全部文件列表数据
                File_data fdata = (File_data)obj;
                var file = (from f in Files where f.FileId == fileId select f).FirstOrDefault();
                if (file == null)
                {
                    //该文件不存在
                    fdata.CateDatas = new List<Cate_data>();
                    fdata.FeedDatas = new List<Feed_data>();
                    fdata.MarkDatas = new List<Mark_data>();
                    fdata.PCBDatas = new List<PCB_data>();
                    Files.Add(fdata);
                    SaveChanges();
                    //返回保存到数据库的主键值（自增长）
                    var file1 = (from f in Files where f.FileId == fdata.FileId select f).FirstOrDefault();
                    ret = file1.FileId;
                }
                else
                {
                    using (MyContext nextContext = new MyContext())
                    {
                        //更新文件信息，这里fileId必须有实际值
                        nextContext.Files.Attach(fdata);
                        DbEntityEntry<File_data> entry = nextContext.Entry(fdata);
                        entry.State = EntityState.Modified;
                        nextContext.SaveChanges();
                        ret = fdata.FileId;
                    }

                }



            }
            if (obj.GetType() == typeof(PCB_data))
            {
                PCB_data pcbdata = (PCB_data)obj;
                var file = (from f in Files where f.FileId == fileId select f).FirstOrDefault();
                if (file == null)
                {
                    //该文件不存在

                }
                else
                {
                    var pcb = (from p in file.PCBDatas where p.pcbId == pcbdata.pcbId select p).FirstOrDefault();
                    if (pcb == null)
                    {
                        //该pcb不存在，添加到数据库
                        file.PCBDatas.Add(pcbdata);
                        SaveChanges();
                        var pcb1 = (from f in file.PCBDatas where f.pcbId == f.pcbId select f).FirstOrDefault();
                        //返回主键id
                        ret = pcb1.pcbId;
                    }
                    else
                    {
                        //该pcb数据存在，执行更新操作
                        using (MyContext nextContext = new MyContext())
                        {

                            nextContext.PCBs.Attach(pcbdata);
                            DbEntityEntry<PCB_data> entry = nextContext.Entry(pcbdata);
                            entry.State = EntityState.Modified;
                            nextContext.SaveChanges();
                            ret = pcb.pcbId;
                        }

                    }
                }



            }
            else if (obj.GetType() == typeof(Feed_data))
            {
                Feed_data feeddata = (Feed_data)obj;
                var file = (from f in Files where f.FileId == fileId select f).FirstOrDefault();
                if (file == null)
                {
                    //该文件不存在
                }
                else
                {
                    var feed = (from f in file.FeedDatas where f.id == feeddata.id select f).FirstOrDefault();
                    if (feed == null)
                    {
                        //该pcb不存在，添加到数据库
                        feeddata.File_data = file;
                        Feeds.Attach(feeddata);
                        DbEntityEntry<Feed_data> entry = Entry(feeddata);
                        entry.State = EntityState.Added;
                        SaveChanges();
                        var feed1 = (from f in file.FeedDatas where f.FeedId == f.FeedId select f).FirstOrDefault();
                        //返回主键id
                        ret = feed1.id;
                    }
                    else
                    {
                        //该pcb数据存在，执行更新操作
                        using (MyContext nextContext = new MyContext())
                        {
                            nextContext.Feeds.Attach(feeddata);
                            DbEntityEntry<Feed_data> entry = nextContext.Entry(feeddata);
                            entry.State = EntityState.Modified;
                            nextContext.SaveChanges();
                            ret = feeddata.id;
                        }

                    }
                }



            }
            else if (obj.GetType() == typeof(Plug_data))
            {
                Plug_data plugdata = (Plug_data)obj;
                string cateName = plugdata.CateName;
                //
                var file = (from f in Files where f.FileId == fileId select f).FirstOrDefault();
                if (file == null)
                {
                    //该文件不存在
                }
                else
                {
                    //查找插件所属分类
                    var cate = (from c in file.CateDatas where c.CateName == cateName select c).FirstOrDefault();
                    if (cate == null)
                    {
                        //该分类不存在，无法存储该元件
                        //抛出异常
                        throw (new MyException { WarmType = warming.NoCate, Message = "该类型分类数据不存在，请先添加该分类数据" });
                    }
                    else
                    {
                        //查找该插件是否存在
                        var plug = (from p in cate.PlugDatas where p.id == plugdata.id select p).FirstOrDefault();
                        if (plug == null)
                        {
                            //该插件不存在，添加到数据库
                            plugdata.Cate_data = cate;
                            Plugs.Attach(plugdata);
                            DbEntityEntry<Plug_data> entry = Entry(plugdata);
                            entry.State = EntityState.Added;
                            SaveChanges();
                            var plug1 = (from p in cate.PlugDatas where p.PlugId == plugdata.PlugId select p).FirstOrDefault();
                            ret = plug1.id;

                        }
                        else
                        {

                            //该插件数据存在，执行更新操作
                            using (MyContext nextContext = new MyContext())
                            {
                                nextContext.Plugs.Attach(plugdata);
                                DbEntityEntry<Plug_data> entry = nextContext.Entry(plugdata);
                                entry.State = EntityState.Modified;
                                nextContext.SaveChanges();
                                ret = plugdata.id;
                            }

                        }
                    }

                }

            }
            else if (obj.GetType() == typeof(Cate_data))
            {
                Cate_data catedata = (Cate_data)obj;
                var file = (from f in Files where f.FileId == fileId select f).FirstOrDefault();
                if (file == null)
                {
                    //该文件不存在
                }
                else
                {
                    var cate = (from c in file.CateDatas where c.id == catedata.id select c).FirstOrDefault();
                    if (cate == null)
                    {
                        //该pcb不存在，添加到数据库
                        catedata.PlugDatas = new List<Plug_data>();
                        catedata.File_data = file;
                        Cates.Attach(catedata);
                        DbEntityEntry<Cate_data> entry = Entry(catedata);
                        entry.State = EntityState.Added;
                        SaveChanges();
                        var cate1 = (from c in file.CateDatas where c.CateId == catedata.CateId select c).FirstOrDefault();
                        ret = cate1.id;
                    }
                    else
                    {
                        //该pcb数据存在，执行更新操作
                        using (MyContext nextContext = new MyContext())
                        {
                            nextContext.Cates.Attach(catedata);
                            DbEntityEntry<Cate_data> entry = nextContext.Entry(catedata);
                            entry.State = EntityState.Modified;
                            nextContext.SaveChanges();
                            ret = catedata.id;
                        }

                    }
                }




            }
            else if (obj.GetType() == typeof(Mark_data))
            {
                Mark_data markdata = (Mark_data)obj;
                var file = (from f in Files where f.FileId == fileId select f).FirstOrDefault();
                if (file == null)
                {
                    //该文件不存在
                }
                else
                {
                    var mark = (from m in file.MarkDatas where m.MarkId == markdata.MarkId select m).FirstOrDefault();
                    if (mark == null)
                    {
                        //该pcb不存在，添加到数据库

                        markdata.File_data = file;
                        Marks.Attach(markdata);
                        DbEntityEntry<Mark_data> entry = Entry(markdata);
                        entry.State = EntityState.Added;

                        SaveChanges();

                        //返回id
                        var mark1 = (from m in file.MarkDatas where m.MarkId == markdata.MarkId select m).FirstOrDefault();
                        ret = mark1.id;
                    }
                    else
                    {
                        //该pcb数据存在，执行更新操作
                        using (MyContext nextContext = new MyContext())
                        {

                            nextContext.Marks.Attach(markdata);
                            DbEntityEntry<Mark_data> entry = nextContext.Entry(markdata);
                            entry.State = EntityState.Modified;
                            nextContext.SaveChanges();
                            ret = mark.id;
                        }
                    }
                }

            }
            else
            {
                //传入对象不正确
                return -1;
            }
            return ret;
        }

        /// <summary>
        /// 如果object为null，代表删除文件
        /// 否则为删除该OBJECT
        /// </summary>
        /// <param name="fileId">文件编号</param>
        /// <param name="obj"></param>
        /// <returns>删除失败返回-1</returns>


        public int delete(int fileId, object obj)
        {
            int ret = -1;
            if (obj == null)
            {
                var toDelete = (from d in Files where d.FileId == fileId select d).FirstOrDefault();
                if (toDelete == null)
                {
                    //删除的文件不存在
                    ret = -1;
                }
                else
                {
                    Files.Remove(toDelete);
                    SaveChanges();
                    ret = 0;
                }
            }
            else if (obj.GetType() == typeof(PCB_data))
            {
                PCB_data pcb = (PCB_data)obj;
                var file = (from f in Files where f.FileId == fileId select f).FirstOrDefault();
                if (file == null)
                {
                    //不存在该文件,抛出异常
                    ret = -1;
                }
                else
                {
                    var pcb_toDelete = (from d in file.PCBDatas where d.pcbId == pcb.pcbId select d).FirstOrDefault();
                    PCBs.Remove(pcb_toDelete);
                    SaveChanges();
                    ret = 0;
                }



            }
            else if (obj.GetType() == typeof(Cate_data))
            {

                Cate_data cate = (Cate_data)obj;
                var file = (from f in Files where f.FileId == fileId select f).FirstOrDefault();
                if (file == null)
                {
                    //不存在该文件
                    ret = -1;
                }
                else
                {
                    var cate_toDelete = (from d in file.CateDatas where d.id == cate.id select d).FirstOrDefault();
                    if (cate_toDelete == null)
                    {
                        //要删除的分类数据不存在

                    }
                    else
                    {
                        //cascade delete 可以省略删除分类的插件
                        /* foreach (var plug in cate_toDelete.PlugDatas)
                         {
                             //删除该分类下的所有插件
                             cate_toDelete.PlugDatas.Remove(plug);
                         }*/
                        Cates.Attach(cate_toDelete);
                        DbEntityEntry<Cate_data> entry = Entry(cate_toDelete);
                        entry.State = EntityState.Deleted;
                        SaveChanges();
                        //file.CateDatas.Remove(cate_toDelete);
                        //SaveChanges();
                        ret = 0;
                    }

                }


            }
            else if (obj.GetType() == typeof(Plug_data))
            {
                Plug_data plug = (Plug_data)obj;
                var file = (from f in Files where f.FileId == fileId select f).FirstOrDefault();
                if (file == null)
                {
                    //不存在该文件
                    ret = -1;
                }
                else
                {
                    //需要根据插件数据的分类名来添加插件数据
                    var cate = (from c in file.CateDatas where c.CateName == plug.CateName select c).FirstOrDefault();
                    if (cate == null)
                    {
                        //不存在该分类数据
                        throw (new MyException { WarmType = warming.NoCate, Message = "该类型分类数据不存在，请先添加该分类数据" });
                    }
                    else
                    {
                        var plug_toDelete = (from d in cate.PlugDatas where d.id == plug.id select d).FirstOrDefault();
                        Plugs.Remove(plug_toDelete);
                        SaveChanges();
                        ret = 0;
                    }

                }



            }
            else if (obj.GetType() == typeof(Feed_data))
            {
                Feed_data feed = (Feed_data)obj;
                var file = (from f in Files where f.FileId == fileId select f).FirstOrDefault();
                if (file == null)
                {
                    //不存在该文件
                    ret = -1;
                }
                else
                {
                    var feed_toDelete = (from d in Feeds where d.id == feed.id select d).FirstOrDefault();
                    Feeds.Remove(feed_toDelete);
                    SaveChanges();
                    ret = 0;
                }





            }
            else if (obj.GetType() == typeof(Mark_data))
            {
                Mark_data mark = (Mark_data)obj;
                var file = (from f in Files where f.FileId == fileId select f).FirstOrDefault();
                if (file == null)
                {
                    //不存在该文件
                    ret = -1;
                }
                else
                {
                    var mark_toDelete = (from d in Marks where d.id == mark.id select d).FirstOrDefault();
                    Marks.Remove(mark_toDelete);
                    SaveChanges();
                    ret = 0;
                }
            }
            else
            {
                //输入对象有错
                ret = -1;

            }
            return ret;
        }
        /// <summary>
        /// obj.id==-1;表示返回全部信息
        /// </summary>
        /// <param name="fileId"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public List<object> get(int fileId, object obj)
        {
            List<object> fff = new List<object>();
            if (obj.GetType() == typeof(File_data))
            {

                // var fs = (from f in Files where f.FileId == fileId select f);
                foreach (var d in Files)
                {
                    fff.Add(d);
                }

                return fff;
            }
            if (obj.GetType() == typeof(PCB_data))
            {
                PCB_data pcb = (PCB_data)obj;
                var query = (from file in Files where file.FileId == fileId select file).FirstOrDefault();
                if (query == null)
                {
                    //文件不存在！
                }
                else
                {
                    if (pcb.pcbId == -1)//表示返回全部信息
                    {

                        foreach (var pp in query.PCBDatas)
                            fff.Add(pp);

                    }
                    else
                    {
                        var p = (from l in query.PCBDatas where l.pcbId == pcb.pcbId select l).FirstOrDefault();
                        if (p == null)
                        {
                            //PCB数据不存在
                        }
                        else { fff.Add(p); }
                    }

                }

                return fff;
            }
            if (obj.GetType() == typeof(Cate_data))
            {
                Cate_data cate = (Cate_data)obj;
                var query = (from file in Files where file.FileId == fileId select file).FirstOrDefault();
                if (query == null)
                {
                    //文件不存在！
                }
                else
                {
                    if (cate.id == -1)//表示返回全部信息
                    {
                        var p = (from l in query.CateDatas select l).FirstOrDefault();
                        if (p == null) { }
                        else
                        {
                            foreach (var pp in query.CateDatas)
                                fff.Add(pp);
                        }
                    }
                    else
                    {
                        var p = (from l in query.CateDatas where l.id == cate.id select l).FirstOrDefault();
                        if (p == null)
                        {
                            //该分类数据不存在
                        }
                        else { fff.Add(p); }
                    }

                }

                return fff;
            }
            if (obj.GetType() == typeof(Plug_data))
            {
                Plug_data plug = (Plug_data)obj;
                var query = (from file in Files where file.FileId == fileId select file).FirstOrDefault();
                if (query == null)
                {
                    //文件不存在！
                }
                else
                {
                    //需要提供插件数据的分类名（CateName）
                    var cates = (from c in query.CateDatas select c).ToList();
                    if (cates == null)
                    {
                        //该文件没有分类
                    }
                    else
                    {
                        if (plug.id == -1)//表示返回全部信息
                        {
                            foreach (var c in cates)
                            {
                                var pp = (from plg in c.PlugDatas select plg).ToList();
                                fff.AddRange(pp);
                            }

                        }
                        else
                        {
                            //暂时没用。。
                        }
                    }
                }

                return fff;
            }
            if (obj.GetType() == typeof(Feed_data))
            {
                Feed_data pcb = (Feed_data)obj;
                var query = (from file in Files where file.FileId == fileId select file).FirstOrDefault();
                if (query == null)
                {
                    //文件不存在！
                }
                else
                {
                    if (pcb.id == -1)//表示返回全部信息
                    {

                        foreach (var pp in query.FeedDatas)
                            fff.Add(pp);

                    }
                    else
                    {
                        var p = (from l in query.FeedDatas where l.id == pcb.id select l).FirstOrDefault();
                        if (p == null) { }
                        else { fff.Add(p); }

                    }
                }

                return fff;
            }
            if (obj.GetType() == typeof(Mark_data))
            {
                Mark_data pcb = (Mark_data)obj;
                var query = (from file in Files where file.FileId == fileId select file).FirstOrDefault();
                if (query == null)
                {
                    //文件不存在！
                }
                else
                {

                    if (pcb.id == -1)//表示返回全部信息
                    {

                        foreach (var pp in query.MarkDatas)
                            fff.Add(pp);

                    }
                    else
                    {
                        var p = (from l in query.MarkDatas where l.id == pcb.id select l).FirstOrDefault();
                        if (p == null) { }
                        else { fff.Add(p); }
                    }
                }

                return fff;
            }

            return fff;
        }
        public int get(int fileId, String cateName, Object obj)
        {

            var query = (from file in Files where file.FileId == fileId select file).FirstOrDefault();
            if (query == null)
            {
                //文件不存在！
            }
            else
            {
                if (obj.GetType() == typeof(Feed_data))
                {//返回供料位编号
                    var feedid = (from f in query.FeedDatas where f.FeedComp.Equals(cateName) select f.FeedId).FirstOrDefault();
                    return feedid;
                }
                if (obj.GetType() == typeof(Cate_data))
                {
                    //返回 吸嘴类型
                    var nozzleid = (from f in query.CateDatas where f.CateName.Equals(cateName) select f.Nozzle).FirstOrDefault();
                    return nozzleid;
                }
            }
            return -1;

        }

    }
}
