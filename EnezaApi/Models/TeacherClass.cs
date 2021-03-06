﻿using EnezaApi.DataManager;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EnezaApi.Models
{
    public class TeacherClass
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Id { get; set; }
        [ForeignKey("User"), Column(Order = 0)]
        public Int32 teacherId { get; set; }
        [ForeignKey("Class"), Column(Order = 1)]
        public Int32 classId { get; set; }

        public virtual User User { get; set; }
        public virtual Class @Class { get; set; }

        public static List<TeacherClass> GetByTeacherId(int id)
        {
            using (DataContext db = new DataContext())
            {
                return db.TeacherClasses.Where(tc => tc.teacherId == id).ToList();
            }
        }

        public static TeacherClass GetByIds(int classId, int userId)
        {
            using (DataContext db = new DataContext())
            {
                return db.TeacherClasses.Where(tc => tc.classId == classId && tc.teacherId == userId).FirstOrDefault();
            }
        }

        public static TeacherClass AddTeacher(int id, int userId)
        {
            using (DataContext db = new DataContext())
            {
                TeacherClass newTC = new TeacherClass();
                newTC.classId = id;
                newTC.teacherId = userId;

                db.TeacherClasses.Add(newTC);
                db.SaveChanges();

                return newTC;
            }
        }

        public static Boolean RemoveTeacher(int id, int userId)
        {
            using (DataContext db = new DataContext())
            {
                TeacherClass tc = GetByIds(id, userId);
                
                if (tc != null)
                {
                    db.TeacherClasses.Attach(tc);
                    db.TeacherClasses.Remove(tc);
                    db.SaveChanges();

                    return true;
                }

                return false;
            }
        }
    }
}