using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImageLibraryDAL;
using ImageEntity;
using System.Collections.Generic;

namespace ImageManagementTest
{
    [TestClass]
    public class TestClass
    {
        [TestMethod]
        public void AddImageTest()
        {

            ImageDal dal = new ImageDal();
            ImageDetails idetails = new ImageDetails();
            idetails.Name = "Lighthouse.jpg";
            idetails.Image = new byte[] { };
            idetails.Size = 100;
            
            dal.AddImage(idetails);

            List<ImageDetails> resultlist = dal.GetAllImages().FindAll(x => x.Name == "Lighthouse.jpg");
            Assert.AreNotEqual(0, resultlist.Count);

        }

        [TestMethod]
        public void RemoveTest()
        {
            ImageDal dal = new ImageDal();
            //ImageDetails idetails = new ImageDetails();
            //idetails.Id = 5;

            dal.RemoveImage(1034);
            List<ImageDetails> result = dal.GetAllImages().FindAll(x => x.Id==1034);
            Assert.AreEqual(0,result.Count);

        }

        [TestMethod]
        public void RemoveDuplicateTest()
        {
            ImageDal dal = new ImageDal();

            ImageDetails idetails = new ImageDetails();
            idetails.Name = "Lighthouse.jpg";
            idetails.Image = new byte[] { };
            idetails.Size = 100;

            dal.AddImage(idetails);
            dal.AddImage(idetails);

            dal.RemoveDuplicates();

            List<ImageDetails> result = dal.GetAllImages().FindAll(x => x.Name == "Lighthouse.jpg");

            Assert.AreEqual(1, result.Count);


        }

        [TestMethod]
        public void SortTestWithName()
        {
            ImageDal dal = new ImageDal();

            ImageDetails idetails = new ImageDetails();
            idetails.Name = "Lighthouse.jpg";
            idetails.Image = new byte[] { };
            idetails.Size = 100;

            dal.AddImage(idetails);

             ImageDetails idetails1 = new ImageDetails();
            idetails.Name = "Desert.jpg";
            idetails.Image = new byte[] { };
            idetails.Size = 100;

            dal.AddImage(idetails);

            int index1 = dal.Sort(1).FindLastIndex(x => x.Name == "Lighthouse.jpg");
            int index2 = dal.Sort(1).FindLastIndex(x => x.Name == "Desert.jpg");

            Assert.IsTrue(index1 > index2);

            



        }

        [TestMethod]
        public void SortTestWithSize()
        {
            ImageDal dal = new ImageDal();

            ImageDetails idetails = new ImageDetails();
            idetails.Name = "Lighthouse.jpg";
            idetails.Image = new byte[] { };
            idetails.Size = 200;

            dal.AddImage(idetails);

            ImageDetails idetails1 = new ImageDetails();
            idetails.Name = "Desert.jpg";
            idetails.Image = new byte[] { };
            idetails.Size = 100;

            dal.AddImage(idetails);

            int index1 = dal.Sort(1).FindLastIndex(x => x.Name == "Lighthouse.jpg");
            int index2 = dal.Sort(1).FindLastIndex(x => x.Name == "Desert.jpg");

            Assert.IsTrue(index1 > index2);





        }




    }
}
