<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="pitboss_portal.index" EnableViewState="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pitboss Portal</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
    <link href="styles/styles.css" rel="STYLESHEET" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
        <center>
        <div class="mainContainer">
            <div class="gameInfo">
                <h1>Game info</h1>
                <div class="gameInfoHeader">Game name:</div>
                <div class="gameInfoValue"><asp:Literal EnableViewState="false" runat="server" ID="litGameName"></asp:Literal></div>
                <div class="gameInfoHeader">Connection address:</div>
                <div class="gameInfoValue"><asp:Literal EnableViewState="false" runat="server" ID="litConnectionAddress"></asp:Literal></div>
                <div class="gameInfoHeader">Version:</div><div class="gameInfoValue"><asp:Literal EnableViewState="false" runat="server" ID="litGameVersion"></asp:Literal></div>
                <div class="externalLinks">
                    <asp:Literal EnableViewState="false" runat="server" ID="litExternalLinks"></asp:Literal>
                </div>
            </div>
            <div class="timeInfo">
                <h1>Timer info</h1>
                <div class="year">
                    <asp:Literal EnableViewState="false" runat="server" ID="litYear"></asp:Literal></div>
                <div class="timeLeft">
                    <div class="timeLeftHeader">Time left:</div>
                    <div class="timeValue"><asp:Literal EnableViewState="false" runat="server" ID="litTimeLeft"></asp:Literal></div>
                </div>
                <div class="timeSystemTime">
                    <div class="timeSystemTimeHeader">System time (UTC<asp:Literal runat="server" ID="litSystemTimeUTCOffset"></asp:Literal>):</div>
                    <div class="timeValue"><asp:Literal EnableViewState="false" runat="server" ID="litSystemTime"></asp:Literal></div>
                    <div class="yourTime">
                        <div class="timeZonePickerHeader">Your time zone:</div>
                        <div class="timeZonePicker"><asp:DropDownList ID="ddlTimeZone" runat="server" EnableViewState="true" AutoPostBack="true" OnSelectedIndexChanged="ddlTimeZone_SelectedIndexChanged"></asp:DropDownList></div>
                        <div class="yourTimeIs">Your time is:</div>
                        <div class="yourTimeValue"><asp:Literal EnableViewState="false" runat="server" ID="litYourTime"></asp:Literal></div>
                        <div class="turnRollHeader">Turn rolls:</div>
                        <div class="turnRollValue"><asp:Literal EnableViewState="false" runat="server" ID="litTurnRoll"></asp:Literal></div>
                    </div>
                </div>
            <div class="playerInfo">
                <h1>Player Summary</h1>
                <div class="whosPlayedContainer">
                    <div class="whosPlayedSummary">
                        <div class="numberDone">
                            <asp:Literal EnableViewState="false" runat="server" ID="litNumberDone"></asp:Literal>
                            players have played their turn.</div>
                        <div class="numberLoggedIn">
                            <asp:Literal EnableViewState="false" runat="server" ID="litNumberLoggedIn"></asp:Literal>
                            players have logged in but not played.</div>
                        <div class="numberLeft">
                            <asp:Literal EnableViewState="false" runat="server" ID="litNumberLeft"></asp:Literal>
                            players have not logged in this turn.</div>
                    </div>
                </div>
                <asp:Literal EnableViewState="false" runat="server" ID="litPlayerSummary"></asp:Literal>
            </div>
            <div class="eventLog">
                <h1>Event Log</h1>
                <asp:Literal EnableViewState="false" runat="server" ID="litEventLog"></asp:Literal>
            </div>
        </div>
        </center>
    </form>
</body>
</html>
