<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="pitboss_portal.index" EnableViewState="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><asp:Literal runat="server" ID="litTitle">Game name</asp:Literal></title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
    <link href="styles/styles.css" rel="STYLESHEET" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="mainContainer">
            <div class="gameInfo">
                <h1>Game info</h1>
                <div class="gameName"><asp:Literal runat="server" ID="litGameName">Game name</asp:Literal></div>
            </div>
            <div class="timeInfo">
                <h1>Timer info</h1>
                <div class="year"><asp:Literal runat="server" ID="litYear"></asp:Literal></div>
                <div class="timeLeft"><div class="timeLeftHeader">Time left:</div><div class="timeValue"><asp:Literal runat="server" ID="litTimeLeft"></asp:Literal></div></div>
                <div class="timeSystemTime"><div class="timeSystemTimeHeader">System time:</div><div class="timeValue"><asp:Literal runat="server" ID="litSystemTime"></asp:Literal></div></div>
                <div class="turnRoll"><div class="turnRollHeader">Turn rolls:</div><asp:Literal runat="server" ID="litTurnRoll"></asp:Literal></div>
            </div>
            <div class="playerInfo">
                <h1>Player Summary</h1>
                <asp:Literal runat="server" ID="litPlayerSummary"></asp:Literal>
            </div>
            <div class="eventLog">
                <h1>Event Log</h1>
                <asp:Literal runat="server" ID="litEventLog"></asp:Literal>
            </div>
        </div>
    </form>
</body>
</html>
