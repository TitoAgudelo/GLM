using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using IntranetGLM2013.Models;

namespace IntranetGLM2013.DAL
{
    public class GLMEEDInitializer : DropCreateDatabaseAlways<GLMEEDContext>
    {
        protected override void Seed(GLMEEDContext context)
        {
            var lunchItems = new List<LunchItem>
            {
                new LunchItem{Name="Agua",Category=LunchItemCategory.Bebidas, UrlPhoto="~/Images/Menu/Items/agua.png",Like=1,Dislike=2,Status=true},
                new LunchItem{Name="Yuca",Category=LunchItemCategory.Carbohidratos, UrlPhoto="~/Images/Menu/Items/yuca.png",Like=1,Dislike=2,Status=true},
                new LunchItem{Name="Papa",Category=LunchItemCategory.Carbohidratos, UrlPhoto="~/Images/Menu/Items/papa.png",Like=3,Dislike=2,Status=true},
                new LunchItem{Name="Jugo de Maracuya",Category=LunchItemCategory.Bebidas, UrlPhoto="~/Images/Menu/Items/maracuya.png",Like=1,Dislike=2,Status=true},
                new LunchItem{Name="Sopa de pasta",Category=LunchItemCategory.Entradas, UrlPhoto="~/Images/Menu/Items/pasta.png",Like=1,Dislike=2,Status=true},
                new LunchItem{Name="Costillitas",Category=LunchItemCategory.Proteinas, UrlPhoto="~/Images/Menu/Items/costillas.png",Like=1,Dislike=2,Status=true},
                new LunchItem{Name="Pollo",Category=LunchItemCategory.Proteinas, UrlPhoto="~/Images/Menu/Items/pollo.png",Like=1,Dislike=2,Status=true},
                new LunchItem{Name="Ensalada",Category=LunchItemCategory.Vegetales, UrlPhoto="~/Images/Menu/Items/ensalada.png",Like=1,Dislike=2,Status=true},
                new LunchItem{Name="Helado",Category=LunchItemCategory.Postres, UrlPhoto="~/Images/Menu/Items/helado.png",Like=1,Dislike=2,Status=true},
                new LunchItem{Name="Carne de cerdo",Category=LunchItemCategory.Proteinas, UrlPhoto="~/Images/Menu/Items/carne.png",Like=1,Dislike=2,Status=true},
                new LunchItem{Name="Lentejas",Category=LunchItemCategory.Proteinas, UrlPhoto="~/Images/Menu/Items/lentejas.png",Like=1,Dislike=2,Status=true},
            };
            using (context = new GLMEEDContext())
            {
                lunchItems.ForEach(i => context.LunchItems.Add(i));
                context.SaveChanges();
            }
            var dailyLunches = new List<DailyLunch> 
            {
                new DailyLunch{ID=1,LunchDate=DateTime.Parse("2013-12-09").Date, ShortDate=DateTime.Parse("2013-11-05").Date.ToShortDateString(), PublishedStatus=PublishedStatus.Publish, IsEditable=true, isPublished=false, LunchItemId = 1},
                new DailyLunch{ID=2,LunchDate=DateTime.Parse("2013-12-10").Date, ShortDate=DateTime.Parse("2013-11-05").Date.ToShortDateString(), PublishedStatus=PublishedStatus.Publish, IsEditable=true, isPublished=false, LunchItemId = 2},
                new DailyLunch{ID=3,LunchDate=DateTime.Parse("2013-12-09").Date, ShortDate=DateTime.Parse("2013-11-06").Date.ToShortDateString(), PublishedStatus=PublishedStatus.Publish, IsEditable=true, isPublished=false, LunchItemId = 3},
                new DailyLunch{ID=4,LunchDate=DateTime.Parse("2013-12-12").Date, ShortDate=DateTime.Parse("2013-11-06").Date.ToShortDateString(), PublishedStatus=PublishedStatus.Publish, IsEditable=true, isPublished=false, LunchItemId = 4},
                new DailyLunch{ID=5,LunchDate=DateTime.Parse("2013-12-11").Date, ShortDate=DateTime.Parse("2013-11-07").Date.ToShortDateString(), PublishedStatus=PublishedStatus.Publish, IsEditable=true, isPublished=false, LunchItemId = 1}
            };
            using (context = new GLMEEDContext())
            {
                dailyLunches.ForEach(i => context.DailyLunches.Add(i));
                context.SaveChanges();
            }

            var people = new List<Person>
            {
                new Person {ID = 1, Email = "tito@glm.edu.co", Provider = SSOProvider.google},
                new Person {ID = 2, Email = "danielmorenog@glm.edu.co", Provider = SSOProvider.google},
                new Person {ID = 3, Email = "tito@gmail.com", Provider = SSOProvider.google},
                new Person {ID = 4, Email = "tito@yahoo.com", Provider = SSOProvider.yahoo},
                new Person {ID = 5, Email = "tito@hotmail.com", Provider = SSOProvider.microsoft},
                new Person {ID = 6, Email = "alferrand@yahoo.com", Provider = SSOProvider.yahoo}
            };
            using (context = new GLMEEDContext())
            {
                people.ForEach(i => context.People.Add(i));
                context.SaveChanges();
            }
            var roles = new List<Role>
            {
                new Role{ID=1, Name="Opción 1", Description="La opción 1 es una prueba", IconURL="", InMenuPersonal=false, InMenuPpal=true, IsActive=true, Action=ActionRole.view, IdFather=0},
                new Role{ID=1, Name="Opción 2", Description="La opción 2 es una prueba", IconURL="", InMenuPersonal=false, InMenuPpal=true, IsActive=true, Action=ActionRole.view, IdFather=0},
                new Role{ID=1, Name="Opción 3", Description="La opción 3 es una prueba", IconURL="", InMenuPersonal=false, InMenuPpal=true, IsActive=true, Action=ActionRole.view, IdFather=0},
                new Role{ID=1, Name="Opción 4", Description="La opción 4 es una prueba", IconURL="", InMenuPersonal=false, InMenuPpal=true, IsActive=true, Action=ActionRole.view, IdFather=0},
                new Role{ID=1, Name="Opción 5", Description="La opción 5 es una prueba", IconURL="", InMenuPersonal=false, InMenuPpal=true, IsActive=true, Action=ActionRole.view, IdFather=0},
                new Role{ID=1, Name="Opción 6", Description="La opción 6 es una prueba", IconURL="", InMenuPersonal=false, InMenuPpal=true, IsActive=true, Action=ActionRole.view, IdFather=0},
                new Role{ID=1, Name="Opción 7", Description="La opción 7 es una prueba", IconURL="", InMenuPersonal=false, InMenuPpal=true, IsActive=true, Action=ActionRole.view, IdFather=0},
                new Role{ID=1, Name="Opción 8", Description="La opción 8 es una prueba", IconURL="", InMenuPersonal=false, InMenuPpal=true, IsActive=true, Action=ActionRole.view, IdFather=0}

            };
            using (context = new GLMEEDContext())
            {
                roles.ForEach(i => context.Roles.Add(i));
                context.SaveChanges();
            }
        }
    }
}