<%@ Page Title="Contato" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WingtipToys.Contact" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Fale conosco.</h2>
    </hgroup>

    <section class="contact">
        <header>
            <h3>Telefone:</h3>
        </header>
        <p>
            <span class="label">Main:</span>
            <span>+55(48)3204-5444</span>
        </p>
    </section>

    <section class="contact">
        <header>
            <h3>Email:</h3>
        </header>
        <p>
            <span class="label">Support:</span>
            <span><a href="mailto:suporte@wingtiptoys.com">suporte@wingtiptoys.com</a></span>
        </p>
        <p>
            <span class="label">Marketing:</span>
            <span><a href="mailto:marketing@wingtiptoys.com">marketing@wingtiptoys.com</a></span>
        </p>
        <p>
            <span class="label">General:</span>
            <span><a href="mailto:geral@wingtiptoys.com">geral@wingtiptoys.com</a></span>
        </p>
    </section>

    <section class="contact">
        <header>
            <h3>Endereço:</h3>
        </header>
        <p>
            De Ninguém, Terras<br />
            Fulano, CI 98052-6399
        </p>
    </section>
</asp:Content>