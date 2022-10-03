<%@ Page Title="Sobre" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WingtipToys.About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Nosso negócio é brinquedos.</h2>
    </hgroup>

    <article>
        <p>        
            Fazemos carros de brinquedo.
        </p>

        <p>        
            Fazemos barcos de brinquedo.
        </p>

        <p>        
            Fazemos aviões de brinquedo.
        </p>
        <p>        
            E agora, foguetes de brinquedo também!
        </p>
    </article>

    <aside>
        <h3>Wingtip Toys</h3>
        <p>        
            Fazendo com que seus sonhos de criança voltem a se tornar realidade.
        </p>
        <ul>
            <li><a runat="server" href="~/">Home</a></li>
            <li><a runat="server" href="~/About.aspx">About</a></li>
            <li><a runat="server" href="~/Contact.aspx">Contact</a></li>
        </ul>
    </aside>
</asp:Content>