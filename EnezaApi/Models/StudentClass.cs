using EnezaApi.DataManager;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnezaApi.Models
{
    public class StudentClass
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Id { get; set; }
        [ForeignKey("User"), Column(Order = 0)]
        public Int32 studentId { get; set; }
        [ForeignKey("Class"), Column(Order = 1)]
        public Int32 classId { get; set; }

        public virtual User User { get; set; }
        public virtual Class @Class { get; set; }

        public static List<StudentClass> GetByClassId(int classId)
        {
            using (DataContext db = new DataContext())
            {
                return db.StudentClasses.Where(sc => sc.classId == classId).ToList();
            }
        }

        public static List<StudentClass> GetByStudentId(int id)
        {
            using (DataContext db = new DataContext())
            {
                return db.StudentClasses.Where(tc => tc.studentId == id).ToList();
            }
        }

        public static StudentClass GetByIds(int classId, int userId)
        {
            using (DataContext db = new DataContext())
            {
                return db.StudentClasses.Where(tc => tc.classId == classId && tc.studentId == userId).FirstOrDefault();
            }
        }

        public static StudentClass AddStudent(int id, int userId)
        {
            using (DataContext db = new DataContext())
            {
                StudentClass newSC = new StudentClass();
                newSC.classId = id;
                newSC.studentId = userId;

                db.StudentClasses.Add(newSC);
                db.SaveChanges();

                return newSC;
            }
        }

        public static Boolean RemoveStudent(int id, int userId)
        {
            using (DataContext db = new DataContext())
            {
                StudentClass sc = GetByIds(id, userId);

                if (sc != null)
                {
                    db.StudentClasses.Attach(sc);
                    db.StudentClasses.Remove(sc);
                    db.SaveChanges();

                    return true;
                }

                return false;
            }
        }
    }
}