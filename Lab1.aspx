<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lab1.aspx.cs" Inherits="Lab2.Lab1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trikampiai</title>
     <link rel="stylesheet" href="styles.css" runat="server" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="top">
            <div> <input id="FileUpload1" type="file" runat="server" />
            <asp:Button ID="Upload1" runat="server" OnClick="Upload1_Click" Text="Pateikti" CssClass="uploadButton" /></div>
            <div> <input id="FileUpload2" type="file" runat="server" />
            <asp:Button ID="Upload2" runat="server" OnClick="Upload2_Click" Text="Pateikti" CssClass="uploadButton" /></div>
           
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Skaičiuoti" CssClass="button" />
        </div>
        
        <div class ="container">
            <div class ="container__column column__card column__card-red">
                <asp:Label ID="Header1" runat="server" Text="Pradiniai trikampiai &quot;U5a.txt&quot;" CssClass="card__header"></asp:Label>
                <asp:Label ID="Nera1" runat="server" CssClass="none" Text="Nėra tokių trikampių."></asp:Label>
                <asp:Table ID="start1" runat="server" GridLines="Both"></asp:Table>
            </div>

            <div class ="container__column column__tworows">
                <div class ="column__card column__card-cyan">
                    <asp:Label ID="Header2" runat="server" Text="Pradiniai taškai &quot;U5b.txt&quot;" CssClass="card__header"></asp:Label>
                    <asp:Label ID="Nera2" runat="server" CssClass="none" Text="Nėra tokių trikampių."></asp:Label>
                    <asp:Table ID="start2" runat="server" GridLines="Both"></asp:Table>
                </div>

                <div class="column__card column__card-orange">
                    <asp:Label ID="Header3" runat="server" Text="Surasti trikampiai" CssClass="card__header">
                    </asp:Label>
                    <asp:Label ID="Nera3" runat="server" Text="Nėra tokių trikampių." CssClass="none"></asp:Label>
                    <asp:Table ID="results1" runat="server" GridLines="Both"></asp:Table>
                </div>
            </div>
            <div class ="container__column column__card column__card-blue">
                <asp:Label ID="Header4" runat="server" Text="Nerasti/negalimi trikampiai" CssClass="card__header"></asp:Label>
                <asp:Label ID="Nera4" runat="server" Text="Nėra tokių trikampių." CssClass="none"></asp:Label>
                <asp:Table ID="results2" runat="server" GridLines="Both"></asp:Table>
            </div>
        </div>
        <div class ="footer">

            <asp:Label ID="Delete" runat="server" Text="NORINT IŠTRINTI TRIKAMPĮ ĮVESKITE JO KOORDINATES:"></asp:Label>
            <asp:Label ID="DeleteText" runat="server" Text ="(ĮVESKITE TOKIA EILĖS TVARKA, KOKIA YRA LENTELĖJE)"></asp:Label>
            <div class="footer__inputs">
                <asp:Label ID="Label1" runat="server" Text="X1"></asp:Label>
                <asp:Label ID="Label2" runat="server" Text="Y1"></asp:Label>
                <asp:Label ID="Label3" runat="server" Text="X2"></asp:Label>
                <asp:Label ID="Label4" runat="server" Text="Y2"></asp:Label>
                <asp:Label ID="Label5" runat="server" Text="X3"></asp:Label>
                <asp:Label ID="Label6" runat="server" Text="Y3"></asp:Label>
            </div>
            <div class="footer__inputs">
                <asp:TextBox ID="X1" runat="server" placeholder="0"></asp:TextBox>
                <asp:TextBox ID="Y1" runat="server" placeholder="0"></asp:TextBox>
                <asp:TextBox ID="X2" runat="server" placeholder="0"></asp:TextBox>
                <asp:TextBox ID="Y2" runat="server" placeholder="0"></asp:TextBox>
                <asp:TextBox ID="X3" runat="server" placeholder="0"></asp:TextBox>
                <asp:TextBox ID="Y3" runat="server" placeholder="0"></asp:TextBox>
              </div>
            <asp:Label ID="Error" runat="server" Text ="VESKITE SVEIKUOSIUS SKAIČIUS IR NEPALIKITE TUŠČIŲ LAUKŲ!" CssClass ="red none"></asp:Label>
             <asp:Button ID="Trinti" runat="server" Text="Trinti" CssClass="button margin-top" OnClick="Trinti_Click" />
            <asp:Label ID="Success" runat="server" CssClass ="footer__success"></asp:Label>
        </div>
    </form>
</body>
</html>
