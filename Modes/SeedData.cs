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

                if (context.Movie.Any())
                {
                    return;
                }

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
                }
                    );

                context.UserWallpaper.AddRange(
                    new UserWallpaper()
                    {
                        Name = "demo01",
                        Created = DateTime.Parse("1896-1-9"),
                        Image = ImageToByte(Image.FromFile("C:\\Users\\TAN18\\Desktop\\壁纸\\wallhaven-72yz39.jpg"))

                    },
                    new UserWallpaper()
                    {
                        Name = "demo01",
                        Created = DateTime.Parse("1896-1-9"),
                        Image = ImageToByte(Image.FromFile("C:\\Users\\TAN18\\Desktop\\壁纸\\wallhaven-exoyql.jpg"))

                    },
                    new UserWallpaper()
                    {
                        Name = "demo02",
                        Created = DateTime.Parse("1896-1-9"),
                        Image = ImageToByte(Image.FromFile("C:\\Users\\TAN18\\Desktop\\壁纸\\wallhaven-jx9m6m.jpg"))

                    },
                    new UserWallpaper()
                    {
                        Name = "demo02",
                        Created = DateTime.Parse("1896-1-9"),
                        Image = ImageToByte(Image.FromFile("C:\\Users\\TAN18\\Desktop\\壁纸\\wallhaven-l892py.jpg"))

                    },
                    new UserWallpaper()
                    {
                        Name = "demo02",
                        Created = DateTime.Parse("1896-1-9"),
                        Image = ImageToByte(Image.FromFile("C:\\Users\\TAN18\\Desktop\\壁纸\\wallhaven-o59r95.jpg"))

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

            MemoryStream stream = new MemoryStream(bytes);
            return Image.FromStream(stream);
        }
    }
}
