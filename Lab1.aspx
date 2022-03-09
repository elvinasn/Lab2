<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lab1.aspx.cs" Inherits="Lab2.Lab1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trikampiai</title>
    <link rel="stylesheet" href="styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="top">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Vykdyti" CssClass="run" />
        </div>
        
        <div class ="container">
            <div class ="container__column column__card column__card-red">
                <asp:Label ID="Header1" runat="server" Text="Pradiniai duom. &quot;U5a.txt&quot;" CssClass="card__header"></asp:Label>
                <asp:Table ID="start1" runat="server" GridLines="Both"></asp:Table>
            </div>

            <div class ="container__column column__tworows">
                <div class ="column__card column__card-cyan">
                    <asp:Label ID="Header2" runat="server" Text="Pradiniai duom. &quot;U5b.txt&quot;" CssClass="card__header"></asp:Label>
                    <asp:Table ID="start2" runat="server" GridLines="Both"></asp:Table>
                </div>

                <div class="column__card column__card-orange">
                    <asp:Label ID="Header3" runat="server" Text="Surasti trikampiai" CssClass="card__header"></asp:Label>
                    <asp:Table ID="results1" runat="server" GridLines="Both"></asp:Table>
                </div>
            </div>
            <div class ="container__column column__card column__card-blue">
                <asp:Label ID="Header4" runat="server" Text="Nerasti/negalimi trikampiai" CssClass="card__header"></asp:Label>
                <asp:Table ID="results2" runat="server" GridLines="Both"></asp:Table>
            </div>
        </div>
    </form>
</body>
</html>
