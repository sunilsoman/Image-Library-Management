<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ImagePresentationLibrary.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript" type="text/javascript">
        function SelectRadiobutton(radio) {
            var rbtn = document.getElementById(radio.id);
            var rbtnlist = document.getElementsByTagName("input");
            for(i= 0; i<rbtnlist.length;i++)
            {
                if(rbtnlist[i].type=="radio"&&rbtnlist[i].id!=rbtn.id)
                {
                    rbtnlist[i].checked = false;
                }
            }

            document.getElementById("hdSelectedImage").value = document.getElementById(rbtn.id).nextSibling.nextSibling.nextSibling.nextSibling.value;
        }


    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        &nbsp;&nbsp;&nbsp;
    
        <asp:Button ID="Button1" runat="server" OnClick="Add_Click" Text="Add" Width="94px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="Remove" Width="102px" OnClick="Remove_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" Text="Remove Duplicates" Width="130px" OnClick="RemoveDuplicates_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem Value="0">-SELECT-</asp:ListItem>
            <asp:ListItem Value="1">Name</asp:ListItem>
            <asp:ListItem Value="2">Size</asp:ListItem>
        </asp:DropDownList>
    
    </div>
         <br />
         <br />
        &nbsp;&nbsp;
        <asp:FileUpload ID="FileUpload1" runat="server" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button4" runat="server" OnClick="Upload_Click" Text="Upload" Width="92px" />
        <br />
         <br />
        <div>
            <asp:ListView ID="ListView1" runat="server" ClientIDMode="Predictable">
                <ItemTemplate>
                   &nbsp;
                   <div>
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("ImageUrl").ToString() %>' Width="100" Height="100"></asp:Image>
                   <br />
                     <asp:RadioButton ID="Radiobutton" runat="server" OnClick="javascript:SelectRadiobutton(this)"/>
                   <asp:Label runat ="server" Text='<%# Eval("Name").ToString() %>'></asp:Label>
                    <asp:HiddenField runat ="server" Value='<%# Eval("Id").ToString() %>' />
                    </div>    
                </ItemTemplate>
            </asp:ListView>
            <asp:HiddenField ID="hdSelectedImage" runat="server" />
        </div>
    </form>
</body>
</html>
