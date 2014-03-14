<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="civstats.aspx.cs" Inherits="pitboss_portal.civstats" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <asp:Literal runat="server" ID="litTitle">Game name</asp:Literal></title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
    <link href="styles/civstats.css" rel="STYLESHEET" type="text/css">
    <%--	<script language="JavaScript" src="scripts/countdown.js" type="text/javascript"></script>
	<script language="JavaScript" src="scripts/hiderows.js" type="text/javascript"></script>--%>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="maintable" width="100%" cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td class="headertime" align="left">9:58 am <a class="headertime" href="register.php">(GMT -7)</a></td>
                    <td height="20" class="pageheader" align="right">
                        <a class="pageheader" href="login.php">Log In / Create Account</a>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" valign="top" class="maincontent" width="100%">
                        <!-- Was width 800 -->
                        <div align="center">
                            <img src="images/CivIV_logo_med.png" width="500" height="125" alt="Civ 4 Logo"></div>
                        <table align="center" width="720" class="box">
                            <tr>
                                <td class="sitenavbartitle" align="center" width="120">Site Navigation:</td>
                                <td class="sitenavbar" align="center"><a class="sitenavbar" href="index.php">Site News</a></td>
                                <td class="sitenavbar" align="center"><a class="sitenavbar" href="faq.php">FAQ</a></td>
                                <td class="sitenavbar" align="center"><a class="sitenavbar" href="allgames.php">List of Games</a></td>
                                <td class="sitenavbar" align="center"><a class="sitenavbar" href="addgame.php">Add a Game</a></td>
                                <td class="sitenavbar" align="center"><a class="sitenavbar" href="download.php">Uploader</a></td>
                            </tr>
                        </table>
                        <br>
                        <table cellpadding="1" cellspacing="2" border="0" width="720" align="center">
                            <tr>
                                <td class="headingbar" align="center">Game Overview for RBP15 - Realms Beyond Pitboss 15 : <a class="headingbar" href="viewyear.php?gameid=2607&amp;year=820">820 AD</a></td>
                            </tr>
                        </table>
                        <table cellpadding="1" cellspacing="2" border="0" width="720" align="center">
                            <tr>
                                <td class="warningbar" align="center">The uploader is currently not connected, so stats might be out of date.</td>
                            </tr>
                        </table>
                        <br>
                        <table align="center" width="550">
                            <tr>
                                <td class="heading" colspan="4" align="center">Game Information</td>
                            </tr>
                            <tr>
                                <td class="infotitle" width="100">Map Type</td>
                                <td class="info" width="155">Continents</td>
                                <td class="infotitle" width="140">Turn Timer</td>
                                <td class="info" width="155">24 hours</td>
                            </tr>
                            <tr>
                                <td class="infotitle">Climate</td>
                                <td class="info">Temperate</td>
                                <td class="infotitle">Turn Limit</td>
                                <td class="info">None</td>
                            </tr>
                            <tr>
                                <td class="infotitle">Sea Level</td>
                                <td class="info">Medium</td>
                                <td class="infotitle">City Elimination Limit</td>
                                <td class="info">None</td>
                            </tr>
                            <tr>
                                <td class="infotitle">Era</td>
                                <td class="info">Ancient</td>
                                <td class="infotitle">Speed</td>
                                <td class="info">Normal</td>
                            </tr>
                            <tr>
                                <td class="infotitle">Victories</td>
                                <td class="info" colspan="3">Score, Time, Conquest, Domination, Cultural, Space Race, Diplomatic</td>
                            </tr>
                            <tr>
                                <td class="infotitle">Options</td>
                                <td class="info" colspan="3">&nbsp;</td>
                            </tr>
                        </table>
                        <br>
                        <!--
		<table align="center">
			<tr><td align="center" class="heading">Score Graph</td></tr>
			<tr><td><img src="graphs/scoregraph.png?gameid=2607" alt="Score Graph"></td></tr>
		</table>
		<br>
		 -->
                        <table align="center">
                            <tr>
                                <td class="heading" colspan="6" align="center">Player Summary</td>
                            </tr>
                            <tr>
                                <td class="smheading">*</td>
                                <td class="smheading">Player</td>
                                <td class="smheading">Leader</td>
                                <td class="smheading">Nation</td>
                                <td class="smheading">Score</td>
                                <td class="smheading">Status</td>
                            </tr>

                            <tr>
                                <td class="dark"></td>
                                <td class="dark"><a class="dark" href="viewplayer.php?gameid=2607&amp;playernum=3">Krill</a></td>
                                <td class="dark">Genghis Khan</td>
                                <td class="dark" style="color: #633d00;">Mongolia</td>
                                <!-- <td class="grey"><img src="images/leaders/Genghis_icon.jpg"></td> -->
                                <td class="grey">1630</td>
                                <td class="grey">Online</td>
                            </tr>
                            <tr>
                                <td class="dark"></td>
                                <td class="dark"><a class="dark" href="viewplayer.php?gameid=2607&amp;playernum=1">Thoth</a></td>
                                <td class="dark">Frederick</td>
                                <td class="dark" style="color: #b2b2b2;">Germany</td>
                                <!-- <td class="grey"><img src="images/leaders/Frederick_icon.jpg"></td> -->
                                <td class="grey">1365</td>
                                <td class="grey">Online</td>
                            </tr>
                            <tr>
                                <td class="dark"></td>
                                <td class="dark"><a class="dark" href="viewplayer.php?gameid=2607&amp;playernum=5">Lewwyn</a></td>
                                <td class="dark">Tokugawa</td>
                                <td class="dark" style="color: #db0505;">Japan</td>
                                <!-- <td class="grey"><img src="images/leaders/Tokugawa_icon.jpg"></td> -->
                                <td class="grey">1250</td>
                                <td class="grey">Online</td>
                            </tr>
                            <tr>
                                <td class="dark"></td>
                                <td class="dark"><a class="dark" href="viewplayer.php?gameid=2607&amp;playernum=6">Krill</a></td>
                                <td class="dark">Stalin</td>
                                <td class="dark" style="color: #fc5900;">Russia</td>
                                <!-- <td class="grey"><img src="images/leaders/Unknown_icon.jpg"></td> -->
                                <td class="grey">1199</td>
                                <td class="grey">Online</td>
                            </tr>
                            <tr>
                                <td class="dark"></td>
                                <td class="dark"><a class="dark" href="viewplayer.php?gameid=2607&amp;playernum=2">Serdoa</a></td>
                                <td class="dark">Boudica</td>
                                <td class="dark" style="color: #e5a551;">Celtia</td>
                                <!-- <td class="grey"><img src="images/leaders/Unknown_icon.jpg"></td> -->
                                <td class="grey">582</td>
                                <td class="grey">Online</td>
                            </tr>
                            <tr>
                                <td class="dark">*</td>
                                <td class="dark"><a class="dark" href="viewplayer.php?gameid=2607&amp;playernum=4">pindicator</a></td>
                                <td class="dark">Saladin</td>
                                <td class="dark" style="color: #006300;">Arabia</td>
                                <!-- <td class="grey"><img src="images/leaders/Saladin_icon.jpg"></td> -->
                                <td class="grey">0</td>
                                <td class="grey">Eliminated</td>
                            </tr>
                            <tr>
                                <td class="dark"></td>
                                <td class="dark"><a class="dark" href="viewplayer.php?gameid=2607&amp;playernum=7">Commodore</a></td>
                                <td class="dark">Abraham Lincoln</td>
                                <td class="dark" style="color: #3566ff;">America</td>
                                <!-- <td class="grey"><img src="images/leaders/Unknown_icon.jpg"></td> -->
                                <td class="grey">0</td>
                                <td class="grey">Eliminated</td>
                            </tr>
                        </table>
                        <br>
                        <br>
                        <table align="center" id="gamelog">
                            <tr>
                                <td align="center" class="heading" colspan="3">Game Log</td>
                            </tr>
                            <tr>
                                <td align="center" class="smheading" colspan="3">
                                    <img src="images/gamelogbuttons/loginout_on.png" style="cursor: pointer;" alt="Toggle player login/logout events" title="Toggle player login/logout events" onclick="showhide('gamelog', 'event(4|5)-');togglelogfilter(this)">
                                    <img src="images/gamelogbuttons/score_on.png" style="cursor: pointer;" alt="Toggle score increase/decrease events" title="Toggle score increase/decrease events" onclick="showhide('gamelog', 'event(1|2)-');togglelogfilter(this)">
                                    <img src="images/gamelogbuttons/newturn_on.png" style="cursor: pointer;" alt="Toggle new turn events" title="Toggle new turn events" onclick="showhide('gamelog', 'event(3)-');togglelogfilter(this)">
                                    <img src="images/gamelogbuttons/playerstatus_on.png" style="cursor: pointer;" alt="Toggle player status change events" title="Toggle player status change events" onclick="showhide('gamelog', 'event(6|7)-');togglelogfilter(this)">
                                    <img src="images/gamelogbuttons/turnfinished_on.png" style="cursor: pointer;" alt="Toggle player finished turn events" title="Toggle player finished turn events" onclick="showhide('gamelog', 'event(8)-');togglelogfilter(this)">
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="smheading">Time</td>
                                <td align="center" class="smheading">Player</td>
                                <td align="center" class="smheading">Event</td>
                            </tr>
                            <tr id="event10-7424954-0">
                                <td align="center" class="dark">1/30/14 4:52 pm</td>
                                <td align="center" class="dark"></td>
                                <td align="center" class="event10">Uploader disconnected</td>
                            </tr>
                            <tr id="event5-7424953-6">
                                <td align="center" class="dark">1/30/14 4:52 pm</td>
                                <td align="center" class="dark">Krill</td>
                                <td align="center" class="event5">Logged out</td>
                            </tr>
                            <tr id="event5-7424952-5">
                                <td align="center" class="dark">1/30/14 4:52 pm</td>
                                <td align="center" class="dark">Lewwyn</td>
                                <td align="center" class="event5">Logged out</td>
                            </tr>
                            <tr id="event5-7424951-3">
                                <td align="center" class="dark">1/30/14 4:52 pm</td>
                                <td align="center" class="dark">Krill</td>
                                <td align="center" class="event5">Logged out</td>
                            </tr>
                            <tr id="event5-7424950-2">
                                <td align="center" class="dark">1/30/14 4:52 pm</td>
                                <td align="center" class="dark">Serdoa</td>
                                <td align="center" class="event5">Logged out</td>
                            </tr>
                            <tr id="event5-7424949-1">
                                <td align="center" class="dark">1/30/14 4:52 pm</td>
                                <td align="center" class="dark">Thoth</td>
                                <td align="center" class="event5">Logged out</td>
                            </tr>
                            <tr id="event12-7424948-7">
                                <td align="center" class="dark">1/30/14 4:52 pm</td>
                                <td align="center" class="dark">Commodore</td>
                                <td align="center" class="event12">Eliminated</td>
                            </tr>
                            <tr id="event4-7424947-6">
                                <td align="center" class="dark">1/30/14 4:52 pm</td>
                                <td align="center" class="dark">Krill</td>
                                <td align="center" class="event4">Logged in</td>
                            </tr>
                            <tr id="event4-7424946-5">
                                <td align="center" class="dark">1/30/14 4:52 pm</td>
                                <td align="center" class="dark">Lewwyn</td>
                                <td align="center" class="event4">Logged in</td>
                            </tr>
                            <tr id="event4-7424945-3">
                                <td align="center" class="dark">1/30/14 4:52 pm</td>
                                <td align="center" class="dark">Krill</td>
                                <td align="center" class="event4">Logged in</td>
                            </tr>
                            <tr id="event4-7424944-2">
                                <td align="center" class="dark">1/30/14 4:52 pm</td>
                                <td align="center" class="dark">Serdoa</td>
                                <td align="center" class="event4">Logged in</td>
                            </tr>
                            <tr id="event4-7424943-1">
                                <td align="center" class="dark">1/30/14 4:52 pm</td>
                                <td align="center" class="dark">Thoth</td>
                                <td align="center" class="event4">Logged in</td>
                            </tr>
                            <tr id="event5-7420052-1">
                                <td align="center" class="dark">1/27/14 3:39 pm</td>
                                <td align="center" class="dark">Thoth</td>
                                <td align="center" class="event5">Logged out</td>
                            </tr>
                            <tr id="event1-7420051-1">
                                <td align="center" class="dark">1/27/14 3:37 pm</td>
                                <td align="center" class="dark">Thoth</td>
                                <td align="center" class="event1">Score increased to 1365</td>
                            </tr>
                            <tr id="event4-7420050-1">
                                <td align="center" class="dark">1/27/14 3:35 pm</td>
                                <td align="center" class="dark">Thoth</td>
                                <td align="center" class="event4">Logged in</td>
                            </tr>
                            <tr id="event5-7415795-3">
                                <td align="center" class="dark">1/25/14 6:18 am</td>
                                <td align="center" class="dark">Krill</td>
                                <td align="center" class="event5">Logged out</td>
                            </tr>
                            <tr id="event2-7415772-6">
                                <td align="center" class="dark">1/25/14 6:14 am</td>
                                <td align="center" class="dark">Krill</td>
                                <td align="center" class="event2">Score decreased to 1199</td>
                            </tr>
                            <tr id="event1-7415771-3">
                                <td align="center" class="dark">1/25/14 6:14 am</td>
                                <td align="center" class="dark">Krill</td>
                                <td align="center" class="event1">Score increased to 1630</td>
                            </tr>
                            <tr id="event4-7415758-3">
                                <td align="center" class="dark">1/25/14 6:11 am</td>
                                <td align="center" class="dark">Krill</td>
                                <td align="center" class="event4">Logged in</td>
                            </tr>
                            <tr id="event5-7415756-6">
                                <td align="center" class="dark">1/25/14 6:11 am</td>
                                <td align="center" class="dark">Krill</td>
                                <td align="center" class="event5">Logged out</td>
                            </tr>
                            <tr id="event4-7415755-6">
                                <td align="center" class="dark">1/25/14 6:10 am</td>
                                <td align="center" class="dark">Krill</td>
                                <td align="center" class="event4">Logged in</td>
                            </tr>
                            <tr id="event5-7415754-3">
                                <td align="center" class="dark">1/25/14 6:10 am</td>
                                <td align="center" class="dark">Krill</td>
                                <td align="center" class="event5">Logged out</td>
                            </tr>
                            <tr id="event4-7415751-3">
                                <td align="center" class="dark">1/25/14 6:09 am</td>
                                <td align="center" class="dark">Krill</td>
                                <td align="center" class="event4">Logged in</td>
                            </tr>
                            <tr id="event5-7415750-6">
                                <td align="center" class="dark">1/25/14 6:09 am</td>
                                <td align="center" class="dark">Krill</td>
                                <td align="center" class="event5">Logged out</td>
                            </tr>
                            <tr id="event4-7415741-6">
                                <td align="center" class="dark">1/25/14 6:02 am</td>
                                <td align="center" class="dark">Krill</td>
                                <td align="center" class="event4">Logged in</td>
                            </tr>
                            <tr id="event11-7415740-6">
                                <td align="center" class="dark">1/25/14 6:02 am</td>
                                <td align="center" class="dark">Novice</td>
                                <td align="center" class="event11">Changed name to Krill</td>
                            </tr>
                            <tr id="event5-7415739-3">
                                <td align="center" class="dark">1/25/14 6:01 am</td>
                                <td align="center" class="dark">Krill</td>
                                <td align="center" class="event5">Logged out</td>
                            </tr>
                            <tr id="event11-7415723-3">
                                <td align="center" class="dark">1/25/14 5:30 am</td>
                                <td align="center" class="dark">Commodore</td>
                                <td align="center" class="event11">Changed name to Krill</td>
                            </tr>
                            <tr id="event4-7415722-3">
                                <td align="center" class="dark">1/25/14 5:30 am</td>
                                <td align="center" class="dark">Commodore</td>
                                <td align="center" class="event4">Logged in</td>
                            </tr>
                            <tr id="event5-7403372-6">
                                <td align="center" class="dark">1/19/14 8:01 am</td>
                                <td align="center" class="dark">Novice</td>
                                <td align="center" class="event5">Logged out</td>
                            </tr>
                            <tr id="event4-7403370-6">
                                <td align="center" class="dark">1/19/14 7:59 am</td>
                                <td align="center" class="dark">Novice</td>
                                <td align="center" class="event4">Logged in</td>
                            </tr>
                            <tr id="event5-7402869-3">
                                <td align="center" class="dark">1/18/14 7:15 pm</td>
                                <td align="center" class="dark">Commodore</td>
                                <td align="center" class="event5">Logged out</td>
                            </tr>
                            <tr id="event11-7402864-3">
                                <td align="center" class="dark">1/18/14 7:09 pm</td>
                                <td align="center" class="dark">Krill</td>
                                <td align="center" class="event11">Changed name to Commodore</td>
                            </tr>
                            <tr id="event4-7402863-3">
                                <td align="center" class="dark">1/18/14 7:09 pm</td>
                                <td align="center" class="dark">Krill</td>
                                <td align="center" class="event4">Logged in</td>
                            </tr>
                            <tr id="event1-7402598-6">
                                <td align="center" class="dark">1/18/14 2:26 pm</td>
                                <td align="center" class="dark">Novice</td>
                                <td align="center" class="event1">Score increased to 1236</td>
                            </tr>
                            <tr id="event1-7402597-5">
                                <td align="center" class="dark">1/18/14 2:26 pm</td>
                                <td align="center" class="dark">Lewwyn</td>
                                <td align="center" class="event1">Score increased to 1250</td>
                            </tr>
                            <tr id="event8-7402596-4">
                                <td align="center" class="dark">1/18/14 2:26 pm</td>
                                <td align="center" class="dark">pindicator</td>
                                <td align="center" class="event8">Finished turn</td>
                            </tr>
                            <tr id="event1-7402595-3">
                                <td align="center" class="dark">1/18/14 2:26 pm</td>
                                <td align="center" class="dark">Krill</td>
                                <td align="center" class="event1">Score increased to 1593</td>
                            </tr>
                            <tr id="event1-7402594-2">
                                <td align="center" class="dark">1/18/14 2:26 pm</td>
                                <td align="center" class="dark">Serdoa</td>
                                <td align="center" class="event1">Score increased to 582</td>
                            </tr>
                            <tr id="event1-7402593-1">
                                <td align="center" class="dark">1/18/14 2:26 pm</td>
                                <td align="center" class="dark">Thoth</td>
                                <td align="center" class="event1">Score increased to 1347</td>
                            </tr>
                            <tr id="event3-7402592-0">
                                <td align="center" class="dark">1/18/14 2:26 pm</td>
                                <td align="center" class="dark"></td>
                                <td align="center" class="event3">A new turn has begun. It is now 820 AD</td>
                            </tr>
                            <tr id="event5-7401951-7">
                                <td align="center" class="dark">1/18/14 8:31 am</td>
                                <td align="center" class="dark">Commodore</td>
                                <td align="center" class="event5">Logged out</td>
                            </tr>
                            <tr id="event4-7401923-7">
                                <td align="center" class="dark">1/18/14 8:18 am</td>
                                <td align="center" class="dark">Commodore</td>
                                <td align="center" class="event4">Logged in</td>
                            </tr>
                            <tr id="event5-7400659-6">
                                <td align="center" class="dark">1/17/14 11:03 am</td>
                                <td align="center" class="dark">Novice</td>
                                <td align="center" class="event5">Logged out</td>
                            </tr>
                            <tr id="event4-7400658-6">
                                <td align="center" class="dark">1/17/14 11:02 am</td>
                                <td align="center" class="dark">Novice</td>
                                <td align="center" class="event4">Logged in</td>
                            </tr>
                            <tr id="event9-7398037-0">
                                <td align="center" class="dark">1/15/14 6:38 pm</td>
                                <td align="center" class="dark"></td>
                                <td align="center" class="event9">Uploader connected. Version 1.5.1.0</td>
                            </tr>
                            <tr id="event10-7398024-0">
                                <td align="center" class="dark">1/15/14 6:22 pm</td>
                                <td align="center" class="dark"></td>
                                <td align="center" class="event10">Uploader disconnected</td>
                            </tr>
                            <tr id="event5-7391587-1">
                                <td align="center" class="dark">1/13/14 6:36 am</td>
                                <td align="center" class="dark">Thoth</td>
                                <td align="center" class="event5">Logged out</td>
                            </tr>
                            <tr id="event8-7391583-1">
                                <td align="center" class="dark">1/13/14 6:29 am</td>
                                <td align="center" class="dark">Thoth</td>
                                <td align="center" class="event8">Finished turn</td>
                            </tr>
                            <tr id="event4-7391563-1">
                                <td align="center" class="dark">1/13/14 6:01 am</td>
                                <td align="center" class="dark">Thoth</td>
                                <td align="center" class="event4">Logged in</td>
                            </tr>
                            <tr id="event5-7391514-3">
                                <td align="center" class="dark">1/13/14 5:04 am</td>
                                <td align="center" class="dark">Krill</td>
                                <td align="center" class="event5">Logged out</td>
                            </tr>
                            <tr id="event8-7391513-3">
                                <td align="center" class="dark">1/13/14 5:03 am</td>
                                <td align="center" class="dark">Krill</td>
                                <td align="center" class="event8">Finished turn</td>
                            </tr>
                            <tr id="event4-7391480-3">
                                <td align="center" class="dark">1/13/14 3:45 am</td>
                                <td align="center" class="dark">Krill</td>
                                <td align="center" class="event4">Logged in</td>
                            </tr>
                            <tr id="event5-7389798-3">
                                <td align="center" class="dark">1/12/14 5:31 pm</td>
                                <td align="center" class="dark">Krill</td>
                                <td align="center" class="event5">Logged out</td>
                            </tr>
                            <tr id="event4-7389760-3">
                                <td align="center" class="dark">1/12/14 5:20 pm</td>
                                <td align="center" class="dark">Krill</td>
                                <td align="center" class="event4">Logged in</td>
                            </tr>
                            <tr id="event5-7388384-6">
                                <td align="center" class="dark">1/12/14 12:20 pm</td>
                                <td align="center" class="dark">Novice</td>
                                <td align="center" class="event5">Logged out</td>
                            </tr>
                            <tr id="event8-7388383-6">
                                <td align="center" class="dark">1/12/14 12:20 pm</td>
                                <td align="center" class="dark">Novice</td>
                                <td align="center" class="event8">Finished turn</td>
                            </tr>
                            <tr id="event2-7388358-6">
                                <td align="center" class="dark">1/12/14 11:50 am</td>
                                <td align="center" class="dark">Novice</td>
                                <td align="center" class="event2">Score decreased to 1224</td>
                            </tr>
                            <tr id="event2-7388354-6">
                                <td align="center" class="dark">1/12/14 11:48 am</td>
                                <td align="center" class="dark">Novice</td>
                                <td align="center" class="event2">Score decreased to 1248</td>
                            </tr>
                            <tr id="event2-7388351-6">
                                <td align="center" class="dark">1/12/14 11:46 am</td>
                                <td align="center" class="dark">Novice</td>
                                <td align="center" class="event2">Score decreased to 1254</td>
                            </tr>
                            <tr id="event4-7388313-6">
                                <td align="center" class="dark">1/12/14 11:34 am</td>
                                <td align="center" class="dark">Novice</td>
                                <td align="center" class="event4">Logged in</td>
                            </tr>
                            <tr id="event5-7387919-2">
                                <td align="center" class="dark">1/12/14 8:04 am</td>
                                <td align="center" class="dark">Serdoa</td>
                                <td align="center" class="event5">Logged out</td>
                            </tr>
                            <tr id="event8-7387917-2">
                                <td align="center" class="dark">1/12/14 8:04 am</td>
                                <td align="center" class="dark">Serdoa</td>
                                <td align="center" class="event8">Finished turn</td>
                            </tr>
                            <tr id="event4-7387910-2">
                                <td align="center" class="dark">1/12/14 8:00 am</td>
                                <td align="center" class="dark">Serdoa</td>
                                <td align="center" class="event4">Logged in</td>
                            </tr>
                            <tr id="event5-7387859-6">
                                <td align="center" class="dark">1/12/14 7:22 am</td>
                                <td align="center" class="dark">Novice</td>
                                <td align="center" class="event5">Logged out</td>
                            </tr>
                            <tr id="event5-7387846-7">
                                <td align="center" class="dark">1/12/14 7:16 am</td>
                                <td align="center" class="dark">Commodore</td>
                                <td align="center" class="event5">Logged out</td>
                            </tr>
                            <tr id="event8-7387845-7">
                                <td align="center" class="dark">1/12/14 7:16 am</td>
                                <td align="center" class="dark">Commodore</td>
                                <td align="center" class="event8">Finished turn</td>
                            </tr>
                            <tr id="event4-7387829-6">
                                <td align="center" class="dark">1/12/14 7:11 am</td>
                                <td align="center" class="dark">Novice</td>
                                <td align="center" class="event4">Logged in</td>
                            </tr>
                            <tr id="event4-7387825-7">
                                <td align="center" class="dark">1/12/14 7:08 am</td>
                                <td align="center" class="dark">Commodore</td>
                                <td align="center" class="event4">Logged in</td>
                            </tr>
                            <tr id="event5-7387322-5">
                                <td align="center" class="dark">1/11/14 10:05 pm</td>
                                <td align="center" class="dark">Lewwyn</td>
                                <td align="center" class="event5">Logged out</td>
                            </tr>
                            <tr id="event1-7387321-7">
                                <td align="center" class="dark">1/11/14 10:05 pm</td>
                                <td align="center" class="dark">Commodore</td>
                                <td align="center" class="event1">Score increased to 696</td>
                            </tr>
                            <tr id="event1-7387320-6">
                                <td align="center" class="dark">1/11/14 10:05 pm</td>
                                <td align="center" class="dark">Novice</td>
                                <td align="center" class="event1">Score increased to 1261</td>
                            </tr>
                            <tr id="event1-7387319-5">
                                <td align="center" class="dark">1/11/14 10:05 pm</td>
                                <td align="center" class="dark">Lewwyn</td>
                                <td align="center" class="event1">Score increased to 1232</td>
                            </tr>
                            <tr id="event8-7387318-4">
                                <td align="center" class="dark">1/11/14 10:05 pm</td>
                                <td align="center" class="dark">pindicator</td>
                                <td align="center" class="event8">Finished turn</td>
                            </tr>
                            <tr id="event1-7387317-3">
                                <td align="center" class="dark">1/11/14 10:05 pm</td>
                                <td align="center" class="dark">Krill</td>
                                <td align="center" class="event1">Score increased to 1556</td>
                            </tr>
                            <tr id="event1-7387316-2">
                                <td align="center" class="dark">1/11/14 10:05 pm</td>
                                <td align="center" class="dark">Serdoa</td>
                                <td align="center" class="event1">Score increased to 570</td>
                            </tr>
                            <tr id="event1-7387315-1">
                                <td align="center" class="dark">1/11/14 10:05 pm</td>
                                <td align="center" class="dark">Thoth</td>
                                <td align="center" class="event1">Score increased to 1335</td>
                            </tr>
                            <tr id="event3-7387314-0">
                                <td align="center" class="dark">1/11/14 10:05 pm</td>
                                <td align="center" class="dark"></td>
                                <td align="center" class="event3">A new turn has begun. It is now 800 AD</td>
                            </tr>
                            <tr id="event8-7387313-5">
                                <td align="center" class="dark">1/11/14 10:05 pm</td>
                                <td align="center" class="dark">Lewwyn</td>
                                <td align="center" class="event8">Finished turn</td>
                            </tr>
                            <tr id="event4-7387311-5">
                                <td align="center" class="dark">1/11/14 9:56 pm</td>
                                <td align="center" class="dark">Lewwyn</td>
                                <td align="center" class="event4">Logged in</td>
                            </tr>
                            <tr id="event5-7386576-5">
                                <td align="center" class="dark">1/11/14 8:00 pm</td>
                                <td align="center" class="dark">Lewwyn</td>
                                <td align="center" class="event5">Logged out</td>
                            </tr>
                            <tr id="event4-7386496-5">
                                <td align="center" class="dark">1/11/14 7:56 pm</td>
                                <td align="center" class="dark">Lewwyn</td>
                                <td align="center" class="event4">Logged in</td>
                            </tr>
                            <tr id="event5-7379424-3">
                                <td align="center" class="dark">1/10/14 9:44 am</td>
                                <td align="center" class="dark">Krill</td>
                                <td align="center" class="event5">Logged out</td>
                            </tr>
                            <tr id="event8-7379416-3">
                                <td align="center" class="dark">1/10/14 9:32 am</td>
                                <td align="center" class="dark">Krill</td>
                                <td align="center" class="event8">Finished turn</td>
                            </tr>
                            <tr id="event4-7379387-3">
                                <td align="center" class="dark">1/10/14 9:08 am</td>
                                <td align="center" class="dark">Krill</td>
                                <td align="center" class="event4">Logged in</td>
                            </tr>
                            <tr id="event5-7379378-3">
                                <td align="center" class="dark">1/10/14 8:59 am</td>
                                <td align="center" class="dark">Krill</td>
                                <td align="center" class="event5">Logged out</td>
                            </tr>
                            <tr id="event2-7379377-3">
                                <td align="center" class="dark">1/10/14 8:58 am</td>
                                <td align="center" class="dark">Krill</td>
                                <td align="center" class="event2">Score decreased to 1550</td>
                            </tr>
                            <tr id="event2-7379376-3">
                                <td align="center" class="dark">1/10/14 8:56 am</td>
                                <td align="center" class="dark">Krill</td>
                                <td align="center" class="event2">Score decreased to 1563</td>
                            </tr>
                            <tr id="event4-7379228-3">
                                <td align="center" class="dark">1/10/14 7:54 am</td>
                                <td align="center" class="dark">Krill</td>
                                <td align="center" class="event4">Logged in</td>
                            </tr>
                            <tr id="event5-7379219-1">
                                <td align="center" class="dark">1/10/14 7:50 am</td>
                                <td align="center" class="dark">Thoth</td>
                                <td align="center" class="event5">Logged out</td>
                            </tr>
                            <tr id="event4-7379218-1">
                                <td align="center" class="dark">1/10/14 7:49 am</td>
                                <td align="center" class="dark">Thoth</td>
                                <td align="center" class="event4">Logged in</td>
                            </tr>
                            <tr id="event5-7379217-1">
                                <td align="center" class="dark">1/10/14 7:48 am</td>
                                <td align="center" class="dark">Thoth</td>
                                <td align="center" class="event5">Logged out</td>
                            </tr>
                            <tr id="event8-7379216-1">
                                <td align="center" class="dark">1/10/14 7:47 am</td>
                                <td align="center" class="dark">Thoth</td>
                                <td align="center" class="event8">Finished turn</td>
                            </tr>
                            <tr id="event2-7379215-1">
                                <td align="center" class="dark">1/10/14 7:46 am</td>
                                <td align="center" class="dark">Thoth</td>
                                <td align="center" class="event2">Score decreased to 1303</td>
                            </tr>
                            <tr id="event2-7379209-1">
                                <td align="center" class="dark">1/10/14 7:40 am</td>
                                <td align="center" class="dark">Thoth</td>
                                <td align="center" class="event2">Score decreased to 1309</td>
                            </tr>
                            <tr id="event4-7379206-1">
                                <td align="center" class="dark">1/10/14 7:34 am</td>
                                <td align="center" class="dark">Thoth</td>
                                <td align="center" class="event4">Logged in</td>
                            </tr>
                            <tr id="event5-7379086-6">
                                <td align="center" class="dark">1/10/14 5:18 am</td>
                                <td align="center" class="dark">Novice</td>
                                <td align="center" class="event5">Logged out</td>
                            </tr>
                            <tr id="event4-7379085-6">
                                <td align="center" class="dark">1/10/14 5:17 am</td>
                                <td align="center" class="dark">Novice</td>
                                <td align="center" class="event4">Logged in</td>
                            </tr>
                            <tr id="event5-7379084-6">
                                <td align="center" class="dark">1/10/14 5:17 am</td>
                                <td align="center" class="dark">Novice</td>
                                <td align="center" class="event5">Logged out</td>
                            </tr>
                            <tr id="event8-7379082-6">
                                <td align="center" class="dark">1/10/14 5:16 am</td>
                                <td align="center" class="dark">Novice</td>
                                <td align="center" class="event8">Finished turn</td>
                            </tr>
                        </table>
                        <br>
                        <br>
                        <br>
                        <br>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>



<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
	"http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
    <title>RBP15 - Realms Beyond Pitboss 15</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
    <link href="themes/default/style.css" rel="STYLESHEET" type="text/css">
    <link rel="icon" href="http://www.civstats.com/favicon.ico" type="image/x-icon">
    <link rel="shortcut icon" href="http://www.civstats.com/favicon.ico" type="image/x-icon">
    <link rel="alternate" type="application/rss+xml" title="RBP15 - Realms Beyond Pitboss 15 Turn Status (RSS 2.0)" href="rss.xml?feedtype=0&amp;gameid=2607">
    <link rel="alternate" type="application/rss+xml" title="RBP15 - Realms Beyond Pitboss 15 Game Log (RSS 2.0)" href="rss.xml?&amp;gameid=2607">
    <link rel="alternate" type="application/rss+xml" title="RBP15 - Realms Beyond Pitboss 15 Player Status (RSS 2.0)" href="rss.xml?feedtype=2&amp;gameid=2607">
    <script language="JavaScript" src="scripts/countdown.js" type="text/javascript"></script>
    <script language="JavaScript" src="scripts/hiderows.js" type="text/javascript"></script>
    <!--[if lt IE 7.]>
	<script defer type="text/javascript" src="scripts/pngfix.js"></script>
	<![endif]-->
    <script type="text/javascript">

        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-23290049-1']);
        _gaq.push(['_trackPageview']);

        (function () {
            var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
        })();

    </script>
</head>
<body>
</body>
</html>



