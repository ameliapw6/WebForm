<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Log In.aspx.vb" Inherits="LoginAdmin.Log_In" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Log In</title>
    <link href="style.css" />
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans:wght@400;600;700&family=Poppins:wght@400;600;700&display=swap" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <section>
            <img src="Asset/logo.png" class="logo"/>
        </section>
        <div class="form">
            <h2>Log In</h2>
            <asp:TextBox ID="Textbox1" placeholder="Username" runat="server"></asp:TextBox><br />
            <input id="Password1" placeholder="Password" type="password" /> <br />
            <asp:Button ID="Login" runat="server" Text="Log In" />


        </div>
    </form>
</body>
</html>
