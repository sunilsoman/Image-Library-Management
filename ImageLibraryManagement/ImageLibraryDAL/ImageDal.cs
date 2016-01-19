using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using ImageEntity;


namespace ImageLibraryDAL
{
    public class ImageDal
    {


        public void AddImage(ImageDetails newImage)
        {
            using (ImageClassesDataContext context = new ImageClassesDataContext())
            {
                try
                {

                    ImageTable entity = new ImageTable();
                    entity.Name = newImage.Name;
                    entity.Image = newImage.Image;
                    entity.Size = newImage.Size;
                    context.ImageTables.InsertOnSubmit(entity);
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }


            }

        }


        public void RemoveImage(int imageId)
        {
            using (ImageClassesDataContext context = new ImageClassesDataContext())
            {
                try
                {
                    ImageTable entity = context.ImageTables.SingleOrDefault(x => x.Id == imageId);
                    context.ImageTables.DeleteOnSubmit(entity);
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

        }


        public List<ImageDetails> RemoveDuplicates()
        {

            using (ImageClassesDataContext context = new ImageClassesDataContext())
            {

                try
                {
                    List<ImageTable> entity = context.ImageTables.GroupBy(x => x.Name).Select(y => y.First()).ToList();
                    context.ImageTables.DeleteAllOnSubmit(context.ImageTables);
                    context.ImageTables.InsertAllOnSubmit(entity);
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            List<ImageDetails> imageList = GetAllImages();

            return imageList;
        }


        public List<ImageDetails> Sort(int id)
        {
            List<ImageDetails> imageList = new List<ImageDetails>();
            using (ImageClassesDataContext context = new ImageClassesDataContext())
            {

                try
                {
                    if (id == 1)
                    {
                        var result = (from p in context.ImageTables
                                      orderby p.Name
                                      select p).ToList();

                        AddToImagelist(imageList, result);
                    }
                    else
                    {
                        var result = (from p in context.ImageTables
                                      orderby p.Size
                                      select p).ToList();

                        AddToImagelist(imageList, result);
                    }

                    return imageList;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }



        }

        public List<ImageDetails> GetAllImages()
        {
            List<ImageDetails> imageList = new List<ImageDetails>();

            using (ImageClassesDataContext context = new ImageClassesDataContext())
            {

                try
                {

                    var result = (from p in context.ImageTables
                                  select p).ToList();

                    AddToImagelist(imageList, result);
                }

                catch (Exception ex)
                {
                    throw ex;
                }


            }
            return imageList;

        }


        //Helper method
        private static void AddToImagelist(List<ImageDetails> imageList, List<ImageTable> result)
        {
            foreach (var item in result)
            {

                ImageDetails imageDetail = new ImageDetails();
                imageDetail.Id = item.Id;
                imageDetail.Image = item.Image.ToArray();
                imageDetail.Size = item.Size;
                imageDetail.Name = item.Name;
                imageDetail.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String(imageDetail.Image, 0, imageDetail.Image.Length);
                imageList.Add(imageDetail);

            }
        }


    }
}