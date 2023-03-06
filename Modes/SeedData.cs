using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using System.Drawing;
using System.Drawing.Imaging;

namespace RazorPagesMovie.Modes
{
    public class SeedData
    {
        public static void Initalize(IServiceProvider serviceProvider)
        {

            using (var context = new RazorPagesMovieContext(serviceProvider.GetRequiredService<DbContextOptions<RazorPagesMovieContext>>()))
            {

                if (context == null || context.Movie == null)
                {
                    throw new ArgumentNullException();

                }

                if (context == null || context.UserWallpaper == null)
                {
                    throw new ArgumentNullException();
                }

             /*   if (context.Movie.Any() && context.UserWallpaper.Any())
                {
                    return;
                }*/

                context.Movie.AddRange(
                  new Movie()
                  {
                      Title = "When Harry Met Sally",
                      ReleaseDate = DateTime.Parse("1989-2-12"),
                      Cenre = "Romantic Comedy",
                      Price = 7.99m
                  },
                      new Movie
                      {
                          Title = "Ghostbusters ",
                          ReleaseDate = DateTime.Parse("1984-3-13"),
                          Cenre = "Comedy",
                          Price = 8.99M
                      },
                  new Movie
                  {
                      Title = "Ghostbusters 2",
                      ReleaseDate = DateTime.Parse("1986-2-23"),
                      Cenre = "Comedy",
                      Price = 9.99M
                  },
                new Movie
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Cenre = "Western",
                    Price = 3.99M
                },
                 new Movie
                 {
                     Title = "When Harry Met Sally",
                     ReleaseDate = DateTime.Parse("1989-2-12"),
                     Cenre = "Romantic Comedy",
                     Price = 7.99M,
                     Rating = "R"
                 }
                    );

                context.UserWallpaper.AddRange(
                    new UserWallpaper()
                    {
                        Name = "demo01",
                        Created = DateTime.Parse("1896-1-9"),
                        Image = ImageToByte(Image.FromFile("G:\\Word Project\\.Net Project\\Mcr Labeler\\Template JPG\\AMatterofHealth.jpg"))

                    },
                    new UserWallpaper()
                    {
                        Name = "demo01",
                        Created = DateTime.Parse("1896-1-9"),
                       Image = ImageToByte(Image.FromFile("G:\\Word Project\\.Net Project\\Mcr Labeler\\Template JPG\\Laserlabel_10069060.jpg"))

                    },
                    new UserWallpaper()
                    {
                        Name = "demo02",
                        Created = DateTime.Parse("1896-1-9"),
                        Image = ImageToByte(Image.FromFile("G:\\Word Project\\.Net Project\\Mcr Labeler\\Template JPG\\KRAS-TYPE_2V_10108360.jpg"))

                    },
                    new UserWallpaper()
                    {
                        Name = "demo02",
                        Created = DateTime.Parse("1896-1-9"),
                       Image = ImageToByte(Image.FromFile("G:\\Word Project\\.Net Project\\Mcr Labeler\\Template JPG\\TopMargin.jpg"))

                    },
                    new UserWallpaper()
                    {
                        Name = "demo02",
                        Created = DateTime.Parse("1896-1-9"),
                       Image = ImageToByte(Image.FromFile("G:\\Word Project\\.Net Project\\Mcr Labeler\\Template JPG\\REODER#32UP_YOUPAY_MCR.jpg"))

                    }

                    );
                context.SaveChanges();



            }
        }

        public static byte[] ImageToByte(Image image)
        {

            MemoryStream stream = new MemoryStream();
            image.Save(stream, ImageFormat.Bmp);
            byte[] bytes = new byte[stream.Length];
            stream.Position = 0;
            stream.Read(bytes, 0, bytes.Length);
            stream.Close();
            return bytes;
        }
        public static Image ByteToImage(byte[] bytes)
        {
            if (bytes == null) return null;
            MemoryStream stream = new MemoryStream(bytes);
            return Image.FromStream(stream);
        }
    }
}
