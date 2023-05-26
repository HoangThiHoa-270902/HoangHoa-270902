
namespace BS.DataAccessLayer
{
    using System.Data.Entity;
    using BS.Models;
    using System.Collections.Generic;
    using System;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class BookInitializer : DropCreateDatabaseIfModelChanges<BookDbContext>
    {
        protected override void Seed(BookDbContext context)
        {
            Category(context);
            Auhtor(context);
            Publisher(context);
            Book(context);
            Manager();
        }

        private static void Manager()
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new BookDbContext()));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new BookDbContext()));

            if (!roleManager.RoleExists("Admin"))
            {
                // first we create Admin rool   
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
                //Here we create a Admin super user who will maintain the website                  
                var user = new ApplicationUser();
                user.UserName = "duongtuc";
                user.Email = "duongtuc@gmail.com";

                string passWord = "Sa123456@";

                var chkUser = manager.Create(user, passWord);

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result = manager.AddToRole(user.Id, "Admin");

                }
            }

            // creating Creating Manager role    
            if (!roleManager.RoleExists("Customer"))
            {
                var role = new IdentityRole();
                role.Name = "Customer";
                roleManager.Create(role);
                var user = new ApplicationUser();
                user.UserName = "visit";
                user.Email = "visit@gmail.com";

                string passWord = "Sa123456@";

                var chkUser = manager.Create(user, passWord);

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result = manager.AddToRole(user.Id, "Customer");

                }

            }
        }
        private static void Publisher(BookDbContext context)
        {
            List<Publisher> publisher = new List<Publisher>()
            {
                new Publisher{Name = "Kim Đồng",Description = "Lịch sử phát triển của nxb"},
                new Publisher{Name = "Thanh Niên",Description = "Lịch sử phát triển của nxb"},
                new Publisher{Name = "Tuổi Trẻ",Description = "Lịch sử phát triển của nxb"},
                new Publisher{Name = "Tri Thức",Description = "Lịch sử phát triển của nxb"},
                new Publisher{Name = "Thông Tin Truyền Thông",Description = "Lịch sử phát triển của nxb"}
            };
            context.Publishers.AddRange(publisher);
            context.SaveChanges();

        }

        private static void Auhtor(BookDbContext context)
        {
            List<Author> author = new List<Author>()
            {
                new Author{AuthorName = "Harper Lee",History = "Harper Lee được sinh ra và lớn lên tại Monroeville,"},
                new Author{AuthorName = "Jeannette Walls",History = "Jeannette Walls được coi như đứa con cưng "},
                new Author{AuthorName = "John Steinbeck",History = "Là tác giả được kính trọng nhất tại quê nhà California,  ."},
                new Author{AuthorName = "Ken Kesey",History = "Dù được sinh ra tại bang Colorado nhưng Ken Kesey lại lớn lên tại bang ."},
                new Author{AuthorName = "Ernest Hemingway",History = "Ernest Hemingway sinh ra tại Oak Park,."}
            };
            context.Authors.AddRange(author);
            context.SaveChanges();

        }

        private static void Category(BookDbContext context)
        {
            List<Category> categories = new List<Category>()
            {
                new Category {CateName ="Sách giáo khoa‎",Description ="Các trang trong thể loại Sách giáo khoa" },
                new Category {CateName ="Sách chính trị‎",Description ="Các trang trong thể loại Sách chính trị‎" },
                new Category {CateName ="Sách khoa học",Description ="Các trang trong thể loại Sách khoa học" },
                new Category {CateName ="Sách thiếu nhi",Description ="Các trang trong thể loại Sách thiếu nhi" },
                new Category {CateName ="Sách kinh doanh‎",Description ="Các trang trong thể loại Sách kinh doanh" },
            };
            context.Categories.AddRange(categories);
            context.SaveChanges();
        }
        private static void Book(BookDbContext context)
        {
            List<Book> book = new List<Book>()
            {
                new Book { Title="Doremon 1",CateId = 1,AuthorId = 1, PubId = 1,Summary ="Doremon quyển truyện tuổi thơ",ImgUrl="doremon1.jpg", Price = 5000, Quantity = 10,CreateDate = DateTime.Now,IsActive=true},
                new Book { Title="Doremon 2",CateId = 2,AuthorId = 3, PubId = 3,Summary ="Doremon quyển truyện tuổi thơ",ImgUrl="doremon2.jpg", Price = 5000, Quantity = 20,CreateDate = DateTime.Now,IsActive=false},
                new Book { Title="Doremon 3",CateId = 2,AuthorId = 4, PubId = 2,Summary ="Doremon quyển truyện tuổi thơ",ImgUrl="doremon3.jpg", Price = 5000, Quantity = 30,CreateDate = DateTime.Now,IsActive=false},
                new Book { Title="Doremon 4",CateId = 2,AuthorId = 2, PubId = 1,Summary ="Doremon quyển truyện tuổi thơ",ImgUrl="doremon4.jpg", Price = 5000, Quantity = 20,CreateDate = DateTime.Now,IsActive=true},
                new Book { Title="Doremon 5",CateId = 1,AuthorId = 1, PubId = 1,Summary ="Doremon quyển truyện tuổi thơ",ImgUrl="doremon5.jpg", Price = 5000, Quantity = 10,CreateDate = DateTime.Now,IsActive=true},
            };
            context.Books.AddRange(book);
            context.SaveChanges();

        }
    }
}
