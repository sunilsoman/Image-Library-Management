using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ImageLibraryDAL;
using ImageEntity;
using System.IO;
using ImageManagementException;

namespace ImagePresentationLibrary
{
    public partial class Home : System.Web.UI.Page
    {
        string filepath = Path.Combine(Path.GetTempPath(), Path.ChangeExtension(Guid.NewGuid().ToString(), ".jpg"));

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ImageDal dal = new ImageDal();
                FileUpload1.Visible = false;

                ListView1.DataSource = dal.GetAllImages();
                ListView1.DataBind();
                Button4.Visible = false;
              //  File.Delete(filepath);
            }
            catch (Exception ex)
            {
                ImageException exception = new ImageException(ex.Message);

            }

        }

        protected void Add_Click(object sender, EventArgs e)
        {
            FileUpload1.Visible = true;
            Button4.Visible = true;

        }

        protected void Upload_Click(object sender, EventArgs e)
        {

            try
            {

                if (FileUpload1.HasFile)
                {
                    ImageDetails iDetails = new ImageDetails();
                    iDetails.Name = FileUpload1.FileName;

                    File.WriteAllBytes(filepath, FileUpload1.FileBytes);

                    FileUpload1.SaveAs(filepath + FileUpload1.FileName);


                    FileInfo fInfo = new FileInfo(filepath);

                    long numBytes = fInfo.Length;

                    //Open FileStream to read file
                    FileStream fStream = new FileStream(filepath, FileMode.Open, FileAccess.Read);

                    //Use BinaryReader to read file stream into byte array.
                    BinaryReader br = new BinaryReader(fStream);

                    //storing byte information in Image field
                    iDetails.Image = br.ReadBytes((int)numBytes);

                    iDetails.Size = numBytes;

                    ImageDal dal = new ImageDal();

                    dal.AddImage(iDetails);

                    ListView1.DataSource = dal.GetAllImages();
                    ListView1.DataBind();


                }
            }
            catch (Exception ex)
            {
                ImageException exception = new ImageException(ex.Message);

            }

        }

        protected void Remove_Click(object sender, EventArgs e)
        {

            try
            {
                ImageDal dal = new ImageDal();
                if(hdCheckRadio.Value=="true")
                dal.RemoveImage(int.Parse(hdSelectedImage.Value));

                ListView1.DataSource = dal.GetAllImages();
                ListView1.DataBind();
            }
            catch (Exception ex)
            {
                ImageException exception = new ImageException(ex.Message);

            }


        }

        protected void RemoveDuplicates_Click(object sender, EventArgs e)
        {
            try
            {
                ImageDal dal = new ImageDal();

                ListView1.DataSource = dal.RemoveDuplicates();
                ListView1.DataBind();
            }
            catch (Exception ex)
            {
                ImageException exception = new ImageException(ex.Message);

            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (int.Parse(DropDownList1.SelectedValue) > 0)
                {
                    ImageDal dal = new ImageDal();

                    ListView1.DataSource = dal.Sort(int.Parse(DropDownList1.SelectedValue));
                    ListView1.DataBind();

                }
            }
            catch (Exception ex)
            {
                ImageException exception = new ImageException(ex.Message);

            }
        }



    }
}