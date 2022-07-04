using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Make_XML
{
    public partial class Main : Form
    {
        RouteInfo route = new RouteInfo();
        ScheduleElement schedule;
        Waypoint waypoint; // = new Waypoint();
        Position position = new Position();
        Leg leg = new Leg();
        //Extension extension = new Extension();
        List<Waypoint> WayPointList = new List<Waypoint>();
        List<ScheduleElement> ScheduleList = new List<ScheduleElement>();
        public int DefaultIDX;
        public bool hasDef = false;
        public string Ltext;
        /*
        Dictionary<string, string> WaypointList = new Dictionary<string, string>();
        Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
        */
        public Main()
        {
            InitializeComponent();
        }
        /*public void SetData()
        {
            route.m_routeName = tbRouteName.Text;
            route.m_routeAuthor = tbRouteAuthor.Text;
            route.m_routeStatus = tbRouteStatus.Text;
            // route.m_validityPeriodStart = tbValidityPeriodStart;
            // route.m_validityPeriodStop = tbValidityPeriodStop;
            route.m_vesselName = tbVesselName.Text;
            if (tbVesselMMSI.Text != "")
            { 
                route.m_vesselMMSI =  Int32.Parse(tbVesselMMSI.Text); 
            }
            if (tbVesselIMO.Text != "")
            {
                route.m_vesselIMO = Int32.Parse(tbVesselIMO.Text);
            }

        }*/

        private void btn_xmlCreate_Click(object sender, EventArgs e)
        {
            try
            {
                // SetData();
                Make_XML_EX_File();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("XML 파일 생성 실패 {0}", ex.ToString()));

            }
            // finally { }
        }

        private void btn_XML_EX_Click(object sender, EventArgs e)
        {
            try
            {
                Make_XMLFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("XML 파일 생성 실패 {0}", ex.ToString()));

            }
            // finally { }
        }

        public void Make_XMLFile()
        {
            XmlTextWriter writer = new XmlTextWriter("ex.xml", Encoding.UTF8);
            //Use indenting for readability.
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 4;
            //writer.WriteString("?xml version=\"1.0\" encoding=\"UTF - 8\"?");

            writer.WriteStartDocument();

            writer.WriteComment($@"

Route Exchange Format (RTZ) XML schema 

Revision 1.0

Source: IEC 61174 Ed 4.0:2015
");

            //Write an element (this one is the root).
            writer.WriteStartElement("route");

            //Write the namespace declaration.
            writer.WriteAttributeString("xmlns", "xsi", null, "http://www.w3.org/2001/XMLSchema-instance");
            writer.WriteAttributeString("xmlns", "http://www.cirm.org/RTZ/1/0");
            writer.WriteAttributeString("version", "1.0");
            writer.WriteAttributeString("xsi", "schemaLocation", null, "http://www.cirm.org/RTZ/1/0 rtz.xsd");

            writer.WriteStartElement("routeinfo");
            writer.WriteAttributeString("routeName", route.m_routeName);
            //string depArr = string.Format("{0}to{1}", route.m_DepPortName, m_ArrPortName);

            //writer.WriteAttributeString("routeName", depArr);
            writer.WriteEndElement();

            writer.WriteStartElement("waypoints");

            writer.WriteStartElement("defaultWaypoint");
            writer.WriteAttributeString("radius", "1.0");


            writer.WriteStartElement("leg");
            writer.WriteAttributeString("portsideXTD", "0.5");
            writer.WriteAttributeString("starboardXTD", "0.1");

            writer.WriteEndElement();
            writer.WriteEndElement();

            // waypoint 하드코딩부분 --> 함수로 만들면 좋을것 같음
            writer.WriteStartElement("waypoint");
            writer.WriteAttributeString("id", "15");
            writer.WriteAttributeString("revision", "1");
            writer.WriteStartElement("position");
            writer.WriteAttributeString("lat", "53.0492");
            writer.WriteAttributeString("lon", "8.87731");
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteStartElement("waypoint");
            writer.WriteAttributeString("id", "52");
            writer.WriteAttributeString("revision", "3");
            writer.WriteStartElement("position");
            writer.WriteAttributeString("lat", "53.0513");
            writer.WriteAttributeString("lon", "8.87509");
            writer.WriteEndElement();

            writer.WriteStartElement("leg");
            writer.WriteAttributeString("portsideXTD", "0.3");
            writer.WriteAttributeString("starboardXTD", "0.3");
            writer.WriteAttributeString("safetyContour", "11.20000000");
            writer.WriteAttributeString("safetyDepth", "22.20000000");
            writer.WriteAttributeString("geometryType", "Orthodrome");
            writer.WriteEndElement();
            writer.WriteEndElement();

            writer.WriteStartElement("waypoint");
            writer.WriteAttributeString("id", "1");
            writer.WriteAttributeString("revision", "1");
            writer.WriteAttributeString("name", "To the pier");
            writer.WriteStartElement("position");
            writer.WriteAttributeString("lat", "53.5123");
            writer.WriteAttributeString("lon", "8.11998");
            writer.WriteEndElement();
            writer.WriteStartElement("leg");
            writer.WriteAttributeString("portsideXTD", "0.1");
            writer.WriteAttributeString("starboardXTD", "0.1");
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteStartElement("waypoint");
            writer.WriteAttributeString("id", "5");
            writer.WriteAttributeString("revision", "3");
            writer.WriteAttributeString("name", "To the pier");
            writer.WriteStartElement("position");
            writer.WriteAttributeString("lat", "53.0492");
            writer.WriteAttributeString("lon", "8.87731");
            writer.WriteEndElement();
            writer.WriteStartElement("leg");
            writer.WriteAttributeString("portsideXTD", "0.1");
            writer.WriteAttributeString("starboardXTD", "0.1");
            writer.WriteAttributeString("safetyContour", "11.20000000");
            writer.WriteAttributeString("safetyDepth", "22.20000000");
            writer.WriteAttributeString("geometryType", "Orthodrome");
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();

            // 하드코딩부분 끝

            // schedules 하드코딩 부분 --> 함수로 변경
            writer.WriteStartElement("schedules");
            writer.WriteStartElement("schedule");
            writer.WriteAttributeString("id", "1");
            writer.WriteAttributeString("name", "schedule1");
            writer.WriteStartElement("manual");
            writer.WriteStartElement("sheduleElement");
            writer.WriteAttributeString("waypointId", "15");
            writer.WriteAttributeString("etd", "2002-11-17T15:25:00Z");
            writer.WriteEndElement();
            writer.WriteStartElement("sheduleElement");
            writer.WriteAttributeString("waypointId", "15");
            writer.WriteAttributeString("eta", "2002-11-17T15:25:00Z");
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteStartElement("calculated");
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteStartElement("schedule");
            writer.WriteAttributeString("id", "2");
            writer.WriteAttributeString("name", "schedule2");
            writer.WriteStartElement("manual");
            writer.WriteStartElement("sheduleElement");
            writer.WriteAttributeString("waypointId", "15");
            writer.WriteAttributeString("etd", "2002-11-17T15:25:00Z");
            writer.WriteEndElement();
            writer.WriteStartElement("sheduleElement");
            writer.WriteAttributeString("waypointId", "15");
            writer.WriteAttributeString("eta", "2002-11-17T15:25:00Z");
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteStartElement("calculated");
            writer.WriteStartElement("sheduleElement");
            writer.WriteAttributeString("waypointId", "15");
            writer.WriteAttributeString("etd", "2002-11-17T15:25:00Z");
            writer.WriteAttributeString("speed", "11.34520000");
            writer.WriteEndElement();
            writer.WriteStartElement("sheduleElement");
            writer.WriteAttributeString("waypointId", "15");
            writer.WriteAttributeString("eta", "2002-12-17T15:25:00Z");
            writer.WriteAttributeString("speed", "12.66635112");
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            // 하드코딩부분 끝


            writer.WriteStartElement("extensions");
            writer.WriteEndElement();

            //WriteWaypoints(writer, m_Route);

            //WriteSchedules(writer);
            //WriteExtensions(writer);

            writer.WriteEndElement();



            //Write the XML to file and close the writer.
            writer.Flush();
            writer.Close();

            string input = "";
            string[] lines = System.IO.File.ReadAllLines(@"ex.xml", Encoding.UTF8);
            foreach (string show in lines)
            {
                if (input == "")
                {
                    input = show;
                }
                else
                {
                    input = input + "\r\n" + show;
                }
            }

            //TextBox에 넣기
            tbXML.Text = input;
        }
        public void Make_XML_EX_File()
        {
            XmlTextWriter writer = new XmlTextWriter("aa.rtz", Encoding.UTF8);
            //Use indenting for readability.
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 4;
            //writer.WriteString("?xml version=\"1.0\" encoding=\"UTF - 8\"?");

            writer.WriteStartDocument();

            writer.WriteComment($@"

Route Exchange Format (RTZ) XML schema 

Revision 1.0

Source: IEC 61174 Ed 4.0:2015
");

            //Write an element (this one is the root).
            writer.WriteStartElement("route");

            //Write the namespace declaration.
            writer.WriteAttributeString("xmlns", "xsi", null, "http://www.w3.org/2001/XMLSchema-instance");
            writer.WriteAttributeString("xmlns", "http://www.cirm.org/RTZ/1/0");
            writer.WriteAttributeString("version", "1.0");
            writer.WriteAttributeString("xsi", "schemaLocation", null, "http://www.cirm.org/RTZ/1/0 rtz.xsd");
            WriteRouteInfo(writer, route);
            WriteWaypoint(writer, waypoint, WayPointList);
            WriteSchedule(writer, schedule);
            //WriteExtension(writer, extension);
            writer.Flush();
            writer.Close();

            string input = "";
            string[] lines = System.IO.File.ReadAllLines(@"aa.rtz", Encoding.UTF8);
            foreach (string show in lines)
            {
                if (input == "")
                {
                    input = show;
                }
                else
                {
                    input = input + "\r\n" + show;
                }
            }

            //TextBox에 넣기
            tbXML.Text = input;
        }

        public void WriteRouteInfo(XmlTextWriter writer, RouteInfo route)
        {
            writer.WriteStartElement("routeInfo");
            if (tbRouteName.Text == "")       // 필수 요소를 입력 안 했을때 오류
            {
                MessageBox.Show("routeName은 필수요소 입니다");
            }
            writer.WriteAttributeString("routeName", tbRouteName.Text);
            if (tbRouteAuthor.Text != "")
            {
                writer.WriteAttributeString("routeAuthor", tbRouteAuthor.Text);
            }
            if (tbRouteStatus.Text != "")
            {
                writer.WriteAttributeString("routeStatus", tbRouteStatus.Text);
            }
            if (tbVesselMMSI.Text != "")
            {
                route.m_vesselMMSI = Int32.Parse(tbVesselMMSI.Text);
                writer.WriteAttributeString("vesselMMSI", route.m_vesselMMSI.ToString("D9")); // 초과값 처리
            }
            if (tbVesselIMO.Text != "")
            {
                route.m_vesselIMO = Int32.Parse(tbVesselIMO.Text);
                writer.WriteAttributeString("vesselIMO", route.m_vesselIMO.ToString("D7")); // 초과값
            }
            if (tbVesselVoyage.Text != "")
            {
                writer.WriteAttributeString("vesselVoyage", tbVesselVoyage.Text);
            }
            if (tbVesselDisplacement.Text != "")
            {
                route.m_vesselDisplacement = Int32.Parse(tbVesselDisplacement.Text);
                writer.WriteAttributeString("vesselDisplacement", route.m_vesselDisplacement.ToString());
            }
            if (tbVesselCargo.Text != "")
            {
                route.m_vesselCargo = Int32.Parse(tbVesselCargo.Text);
                writer.WriteAttributeString("vesselCargo", route.m_vesselCargo.ToString());
            }
            if (tbVesselGM.Text != "")
            {
                route.m_vesselGM = Double.Parse(tbVesselGM.Text);
                writer.WriteAttributeString("vesselGM", route.m_vesselGM.ToString("F2")); // 잘모르겠음 (소수점 자리는 해결, 정수부분 값의 갯수 제한을 못하겠음)
            }
            if (tbOptimizationMethod.Text != "")
            {
                writer.WriteAttributeString("optimizationMethod", tbOptimizationMethod.Text);
            }
            if (tbVesselMaxRoll.Text != "")
            {
                route.m_vesselMaxRoll = Double.Parse(tbVesselMaxRoll.Text);
                writer.WriteAttributeString("vesselMaxRoll", route.m_vesselMaxRoll.ToString("F1"));
            }
            if (tbVesselMaxWave.Text != "")
            {
                route.m_vesselMaxWave = Double.Parse(tbVesselMaxWave.Text);
                writer.WriteAttributeString("vesselMaxWave", route.m_vesselMaxWave.ToString("F1"));
            }
            if (tbVesselMax_Wind.Text != "")
            {
                route.m_vesselMax_Wind = Double.Parse(tbVesselMax_Wind.Text);
                writer.WriteAttributeString("vesselMax_Wind", route.m_vesselMax_Wind.ToString("F1"));
            }
            if (tbVesselSpeedMax.Text != "")
            {
                route.m_vesselSpeedMax = Double.Parse(tbVesselSpeedMax.Text);
                writer.WriteAttributeString("vesselSpeedMax", route.m_vesselSpeedMax.ToString("F1"));
            }
            if (tbVesselServiceMin.Text != "")
            {
                route.m_vesselServiceMin = Double.Parse(tbVesselServiceMin.Text);
                writer.WriteAttributeString("vesselServiceMin", route.m_vesselServiceMin.ToString("F1"));
            }
            if (tbVesselServiceMax.Text != "")
            {
                route.m_vesselServiceMax = Double.Parse(tbVesselServiceMax.Text);
                writer.WriteAttributeString("vesselServiceMax", route.m_vesselServiceMax.ToString("F1"));
            }
            if (tbRouteChangesHistory.Text != "")
            {
                writer.WriteAttributeString("routeChangesHistory", tbRouteChangesHistory.Text);
            }
            writer.WriteEndElement();
        }
        /*
        public void WriteExtension(XmlTextWriter writer, Extension extension)
        {
            writer.WriteStartElement("extensions");
            if (Extension_Checked.Checked)
            {
                writer.WriteStartElement("extension");
                writer.WriteAttributeString("manufacturer", tbManufacturer.Text);
                if (tbVersion.Text != "")
                {
                    writer.WriteAttributeString("version", tbVersion.Text);
                }
                writer.WriteAttributeString("name", tbEXName.Text);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
        */
        public void WriteWaypoint(XmlTextWriter writer, Waypoint waypoint, List<Waypoint> WayPointList)
        {
            writer.WriteStartElement("waypoints");
            if (hasDef)
            {
                writer.WriteStartElement("defaultWaypoint");
                if (WayPointList[DefaultIDX].m_revision != 0)
                {
                    writer.WriteAttributeString("revision", WayPointList[DefaultIDX].m_revision.ToString());
                }
                if (WayPointList[DefaultIDX].m_radius != 0f)
                {
                    writer.WriteAttributeString("radius", WayPointList[DefaultIDX].m_radius.ToString("F1"));
                }
                if (WayPointList[DefaultIDX].hasLeg)
                {
                    writer.WriteStartElement("Leg");
                    if (WayPointList[DefaultIDX].m_starboardXTD != 0f)
                    {
                        writer.WriteAttributeString("starboardXTD", WayPointList[DefaultIDX].m_starboardXTD.ToString("F1"));
                    }
                    if (WayPointList[DefaultIDX].m_portsideXTD != 0f)
                    {
                        writer.WriteAttributeString("portsideXTD", WayPointList[DefaultIDX].m_portsideXTD.ToString("F1"));
                    }
                    if (WayPointList[DefaultIDX].m_safetyContour != 0f)
                    {
                        writer.WriteAttributeString("safetyContour", WayPointList[DefaultIDX].m_safetyContour.ToString("F8"));
                    }
                    if (WayPointList[DefaultIDX].m_safetyDepth != 0f)
                    {
                        writer.WriteAttributeString("safetyDepth", WayPointList[DefaultIDX].m_safetyDepth.ToString("F8"));
                    }
                    /*if (WayPointList[DefaultIDX].m_geometryType != )
                    {
                        writer.WriteAttributeString("geometryType", WayPointList[DefaultIDX].m_geometryType.ToString());
                    }*/
                    if (WayPointList[DefaultIDX].m_planSpeedMin != 0f)
                    {
                        writer.WriteAttributeString("planSpeedMin", WayPointList[DefaultIDX].m_planSpeedMin.ToString("F8"));
                    }
                    if (WayPointList[DefaultIDX].m_planSpeedMax != 0f)
                    {
                        writer.WriteAttributeString("planSpeedMax", WayPointList[DefaultIDX].m_planSpeedMax.ToString("F8"));
                    }
                    if (WayPointList[DefaultIDX].m_draughtForward != 0f)
                    {
                        writer.WriteAttributeString("draughtForward", WayPointList[DefaultIDX].m_draughtForward.ToString("F1"));
                    }
                    if (WayPointList[DefaultIDX].m_draughtAft != 0f)
                    {
                        writer.WriteAttributeString("draughtAft", WayPointList[DefaultIDX].m_draughtAft.ToString("F1"));
                    }
                    if (WayPointList[DefaultIDX].m_staticUKC != 0f)
                    {
                        writer.WriteAttributeString("staticUKC", WayPointList[DefaultIDX].m_staticUKC.ToString("F1"));
                    }
                    if (WayPointList[DefaultIDX].m_dynamicUKC != 0f)
                    {
                        writer.WriteAttributeString("dynamicUKC", WayPointList[DefaultIDX].m_dynamicUKC.ToString("F1"));
                    }
                    if (WayPointList[DefaultIDX].m_masthead != 0f)
                    {
                        writer.WriteAttributeString("masthead", WayPointList[DefaultIDX].m_masthead.ToString("F1"));
                    }
                    if (WayPointList[DefaultIDX].m_legReport != "")
                    {
                        writer.WriteAttributeString("legReport", WayPointList[DefaultIDX].m_legReport);
                    }
                    if (WayPointList[DefaultIDX].m_legInfo != "")
                    {
                        writer.WriteAttributeString("legInfo", WayPointList[DefaultIDX].m_legInfo);
                    }
                    if (WayPointList[DefaultIDX].m_legNote1 != "")
                    {
                        writer.WriteAttributeString("legNote1", WayPointList[DefaultIDX].m_legNote1);
                    }
                    if (WayPointList[DefaultIDX].m_legNote1 != "")
                    {
                        writer.WriteAttributeString("legNote1", WayPointList[DefaultIDX].m_legNote1);
                    }
                    writer.WriteEndElement();

                }
                writer.WriteEndElement();
                WayPointList.RemoveAt(DefaultIDX);
            }
            for (int i = 0; i < WayPointList.Count; i++)
            {
                writer.WriteStartElement("waypoint");
                writer.WriteAttributeString("id", WayPointList[i].m_id.ToString());
                if (WayPointList[i].m_revision != 0)
                {
                    writer.WriteAttributeString("revision", WayPointList[i].m_revision.ToString());
                }
                if (WayPointList[i].m_name != "")
                {
                    writer.WriteAttributeString("name", WayPointList[i].m_name);
                }
                if (WayPointList[i].m_radius != 0f)
                {
                    writer.WriteAttributeString("radius", WayPointList[i].m_radius.ToString());
                }
                writer.WriteStartElement("position");
                writer.WriteAttributeString("lat", WayPointList[i].m_lat.ToString("F6"));
                writer.WriteAttributeString("lon", WayPointList[i].m_lat.ToString("F6"));
                writer.WriteEndElement();

                if (WayPointList[i].hasLeg)
                {
                    writer.WriteStartElement("Leg");
                    if (WayPointList[i].m_starboardXTD != 0f)
                    {
                        writer.WriteAttributeString("starboardXTD", WayPointList[i].m_starboardXTD.ToString("F1"));
                    }
                    if (WayPointList[DefaultIDX].m_portsideXTD != 0f)
                    {
                        writer.WriteAttributeString("portsideXTD", WayPointList[i].m_portsideXTD.ToString("F1"));
                    }
                    if (WayPointList[DefaultIDX].m_safetyContour != 0f)
                    {
                        writer.WriteAttributeString("safetyContour", WayPointList[i].m_safetyContour.ToString("F8"));
                    }
                    if (WayPointList[DefaultIDX].m_safetyDepth != 0f)
                    {
                        writer.WriteAttributeString("safetyDepth", WayPointList[i].m_safetyDepth.ToString("F8"));
                    }
                    /*if (WayPointList[DefaultIDX].m_geometryType != )
                    {
                        writer.WriteAttributeString("geometryType", WayPointList[i].m_geometryType.ToString());
                    }*/
                    if (WayPointList[DefaultIDX].m_planSpeedMin != 0f)
                    {
                        writer.WriteAttributeString("planSpeedMin", WayPointList[i].m_planSpeedMin.ToString("F8"));
                    }
                    if (WayPointList[DefaultIDX].m_planSpeedMax != 0f)
                    {
                        writer.WriteAttributeString("planSpeedMax", WayPointList[i].m_planSpeedMax.ToString("F8"));
                    }
                    if (WayPointList[DefaultIDX].m_draughtForward != 0f)
                    {
                        writer.WriteAttributeString("draughtForward", WayPointList[i].m_draughtForward.ToString("F1"));
                    }
                    if (WayPointList[DefaultIDX].m_draughtAft != 0f)
                    {
                        writer.WriteAttributeString("draughtAft", WayPointList[i].m_draughtAft.ToString("F1"));
                    }
                    if (WayPointList[DefaultIDX].m_staticUKC != 0f)
                    {
                        writer.WriteAttributeString("staticUKC", WayPointList[i].m_staticUKC.ToString("F1"));
                    }
                    if (WayPointList[DefaultIDX].m_dynamicUKC != 0f)
                    {
                        writer.WriteAttributeString("dynamicUKC", WayPointList[i].m_dynamicUKC.ToString("F1"));
                    }
                    if (WayPointList[DefaultIDX].m_masthead != 0f)
                    {
                        writer.WriteAttributeString("masthead", WayPointList[i].m_masthead.ToString("F1"));
                    }
                    if (WayPointList[DefaultIDX].m_legReport != "")
                    {
                        writer.WriteAttributeString("legReport", WayPointList[i].m_legReport);
                    }
                    if (WayPointList[DefaultIDX].m_legInfo != "")
                    {
                        writer.WriteAttributeString("legInfo", WayPointList[i].m_legInfo);
                    }
                    if (WayPointList[DefaultIDX].m_legNote1 != "")
                    {
                        writer.WriteAttributeString("legNote1", WayPointList[i].m_legNote1);
                    }
                    if (WayPointList[DefaultIDX].m_legNote1 != "")
                    {
                        writer.WriteAttributeString("legNote1", WayPointList[i].m_legNote1);
                    }
                    writer.WriteEndElement();

                }

                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
        public void WriteSchedule(XmlTextWriter writer, ScheduleElement schedule)
        {
            int[] overLap = new int[10] {0,0,0,0,0,0,0,0,0,0};
            bool isoverLap = false;
            writer.WriteStartElement("schedules");
            
            if (ScheduleList.Count != 0)
            {
                    for (int i = 0; i < ScheduleList.Count; i++)
                {
                   
                        for (int k = 0; k < 10; k++)
                        {
                            if (ScheduleList[i].m_scheId == overLap[k])
                            {
                                isoverLap = true;
                                break;
                            }
                    }
                    if (!isoverLap)
                    {
                        writer.WriteStartElement("schedule");
                        writer.WriteAttributeString("id", ScheduleList[i].m_scheId.ToString());
                        writer.WriteAttributeString("name", "schedule" + ScheduleList[i].m_scheId.ToString());

                        //if()
                        writer.WriteStartElement("manual");
                        List<ScheduleElement> findSche = ScheduleList.FindAll(element => element.m_scheId == ScheduleList[i].m_scheId);
                        for (int j = 0; j < findSche.Count; j++)
                        {
                            writer.WriteStartElement("scheduleElement");
                            writer.WriteAttributeString("waypointId", findSche[j].m_waypointID.ToString());
                            if (ScheduleList[i].m_etd != DateTime.Now)
                            {
                                writer.WriteAttributeString("etd",findSche[j].m_etd.ToString("yyyy-MM-ddTHH-mm-ssZ"));
                            }
                            if (ScheduleList[i].m_eta != DateTime.Now)
                            {
                                writer.WriteAttributeString("eta",findSche[j].m_eta.ToString("yyyy-MM-ddTHH-mm-ssZ"));
                            }
                            /*
                            if (ScheduleList[i].m_etdWindowBefore != 0)
                            {
                                writer.WriteAttributeString("etdWindowBefore",ScheduleList[i].m_etdWindowBefore.ToString());
                            }
                            if (ScheduleList[i].m_etdWindowAfter != 0)
                            {
                                writer.WriteAttributeString("etdWindowAfter",ScheduleList[i].m_etdWindowAfter.ToString());
                            }
                            if (ScheduleList[i].m_etaWindowBefore != 0)
                            {
                                writer.WriteAttributeString("etaWindowBefore",ScheduleList[i].m_etaWindowBefore.ToString());
                            }
                            if (ScheduleList[i].m_etaWindowAfter != 0)
                            {
                                writer.WriteAttributeString("etaWindowAfter",ScheduleList[i].m_etaWindowAfter.ToString());
                            }
                            if (ScheduleList[i].m_stay != 0)
                            {
                                writer.WriteAttributeString("stay",ScheduleList[i].m_stay.ToString());
                            }
                            */
                            if (findSche[j].m_speed != 0f)
                            {
                                writer.WriteAttributeString("speed", findSche[j].m_speed.ToString("F8"));
                            }
                            if (findSche[j].m_speedWindow != 0f)
                            {
                                writer.WriteAttributeString("speedWindow", findSche[j].m_speedWindow.ToString("F2"));
                            }
                            if (findSche[j].m_windSpeed != 0f)
                            {
                                writer.WriteAttributeString("windSpeed", findSche[j].m_windSpeed.ToString("F2"));
                            }
                            if (findSche[j].m_windDirection != 0)
                            {
                                writer.WriteAttributeString("windDirection", findSche[j].m_windDirection.ToString("F2"));
                            }
                            if (findSche[j].m_currentSpeed != 0)
                            {
                                writer.WriteAttributeString("currentSpeed", findSche[j].m_currentSpeed.ToString("F2"));
                            }
                            if (findSche[j].m_currentDirection != 0)
                            {
                                writer.WriteAttributeString("currentDirection", findSche[j].m_currentDirection.ToString("F2"));
                            }
                            if (findSche[j].m_winLoss != 0)
                            {
                                writer.WriteAttributeString("winLoss", findSche[j].m_winLoss.ToString("F2"));
                            }
                            if (findSche[j].m_waveLoss != 0)
                            {
                                writer.WriteAttributeString("waveLoss", findSche[j].m_waveLoss.ToString("F2"));
                            }
                            if (findSche[j].m_totalLoss != 0)
                            {
                                writer.WriteAttributeString("totalLoss", findSche[j].m_totalLoss.ToString("F2"));
                            }
                            if (findSche[j].m_rpm != 0)
                            {
                                writer.WriteAttributeString("rpm", findSche[j].m_rpm.ToString());
                            }
                            if (findSche[j].m_pitch != 0)
                            {
                                writer.WriteAttributeString("pitch", findSche[j].m_pitch.ToString());
                            }
                            if (findSche[j].m_fuel != 0)
                            {
                                writer.WriteAttributeString("fuel", findSche[j].m_fuel.ToString("F2"));
                            }
                            if (findSche[j].m_relFuelSave != 0)
                            {
                                writer.WriteAttributeString("relFuelSave", findSche[j].m_relFuelSave.ToString("F2"));
                            }
                            if (findSche[j].m_absFuelSave != 0)
                            {
                                writer.WriteAttributeString("absFuelSave", findSche[j].m_absFuelSave.ToString("F2"));
                            }
                            if (findSche[j].m_Note != "")
                            {
                                writer.WriteAttributeString("m_Note", findSche[j].m_Note);
                            }
                            writer.WriteEndElement();

                        }

                        writer.WriteEndElement();
                        overLap[i] = ScheduleList[i].m_scheId;

                    writer.WriteStartElement("calculated");
                    for (int j = 0; j < findSche.Count; j++)
                        {
                            writer.WriteStartElement("scheduleElement");
                            writer.WriteAttributeString("waypointId", findSche[j].m_waypointID.ToString());
                            if (ScheduleList[i].m_etd != DateTime.Now)
                            {
                                writer.WriteAttributeString("etd", findSche[j].m_etd.ToString("yyyy-MM-ddTHH-mm-ssZ"));
                            }
                            if (ScheduleList[i].m_eta != DateTime.Now)
                            {
                                writer.WriteAttributeString("eta", findSche[j].m_eta.ToString("yyyy-MM-ddTHH-mm-ssZ"));
                            }
                            /*
                            if (ScheduleList[i].m_etdWindowBefore != 0)
                            {
                                writer.WriteAttributeString("etdWindowBefore",ScheduleList[i].m_etdWindowBefore.ToString());
                            }
                            if (ScheduleList[i].m_etdWindowAfter != 0)
                            {
                                writer.WriteAttributeString("etdWindowAfter",ScheduleList[i].m_etdWindowAfter.ToString());
                            }
                            if (ScheduleList[i].m_etaWindowBefore != 0)
                            {
                                writer.WriteAttributeString("etaWindowBefore",ScheduleList[i].m_etaWindowBefore.ToString());
                            }
                            if (ScheduleList[i].m_etaWindowAfter != 0)
                            {
                                writer.WriteAttributeString("etaWindowAfter",ScheduleList[i].m_etaWindowAfter.ToString());
                            }
                            if (ScheduleList[i].m_stay != 0)
                            {
                                writer.WriteAttributeString("stay",ScheduleList[i].m_stay.ToString());
                            }
                            */
                            if (findSche[j].m_speed != 0f)
                            {
                                writer.WriteAttributeString("speed", findSche[j].m_speed.ToString("F8"));
                            }
                            if (findSche[j].m_speedWindow != 0f)
                            {
                                writer.WriteAttributeString("speedWindow", findSche[j].m_speedWindow.ToString("F2"));
                            }
                            if (findSche[j].m_windSpeed != 0f)
                            {
                                writer.WriteAttributeString("windSpeed", findSche[j].m_windSpeed.ToString("F2"));
                            }
                            if (findSche[j].m_windDirection != 0)
                            {
                                writer.WriteAttributeString("windDirection", findSche[j].m_windDirection.ToString("F2"));
                            }
                            if (findSche[j].m_currentSpeed != 0)
                            {
                                writer.WriteAttributeString("currentSpeed", findSche[j].m_currentSpeed.ToString("F2"));
                            }
                            if (findSche[j].m_currentDirection != 0)
                            {
                                writer.WriteAttributeString("currentDirection", findSche[j].m_currentDirection.ToString("F2"));
                            }
                            if (findSche[j].m_winLoss != 0)
                            {
                                writer.WriteAttributeString("winLoss", findSche[j].m_winLoss.ToString("F2"));
                            }
                            if (findSche[j].m_waveLoss != 0)
                            {
                                writer.WriteAttributeString("waveLoss", findSche[j].m_waveLoss.ToString("F2"));
                            }
                            if (findSche[j].m_totalLoss != 0)
                            {
                                writer.WriteAttributeString("totalLoss", findSche[j].m_totalLoss.ToString("F2"));
                            }
                            if (findSche[j].m_rpm != 0)
                            {
                                writer.WriteAttributeString("rpm", findSche[j].m_rpm.ToString());
                            }
                            if (findSche[j].m_pitch != 0)
                            {
                                writer.WriteAttributeString("pitch", findSche[j].m_pitch.ToString());
                            }
                            if (findSche[j].m_fuel != 0)
                            {
                                writer.WriteAttributeString("fuel", findSche[j].m_fuel.ToString("F2"));
                            }
                            if (findSche[j].m_relFuelSave != 0)
                            {
                                writer.WriteAttributeString("relFuelSave", findSche[j].m_relFuelSave.ToString("F2"));
                            }
                            if (findSche[j].m_absFuelSave != 0)
                            {
                                writer.WriteAttributeString("absFuelSave", findSche[j].m_absFuelSave.ToString("F2"));
                            }
                            if (findSche[j].m_Note != "")
                            {
                                writer.WriteAttributeString("Note", findSche[j].m_Note);
                            }
                            if (findSche[j].m_etd != findSche[j].m_eta)
                            {
                                Random rand = new Random();
                                double min = 5;
                                double max = 15;
                                double range = max - min;
                                double sample = rand.NextDouble();
                                double scaled = (sample * range) + min;
                                float f = (float)scaled;
                                writer.WriteAttributeString("speed", f.ToString());
                            }
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                    writer.WriteEndElement();
                    }

                }
            }
        }

        public void btn_WP_Click(object sender, EventArgs e)
        {
            string text = "";
            string Ltext = "";
            bool isOverlap = true;
            //try
            //{
                for (int i = 0; i < WayPointList.Count; i++)
                {
                    if (Int32.Parse(tbId.Text) == WayPointList[i].m_id)
                    {
                        isOverlap = false;
                    }
                }
                if (tbId.Text != "" && isOverlap)
                {
                    waypoint = new Waypoint();
                    waypoint.m_id = Int32.Parse(tbId.Text);

                    if (tbRevision.Text != "")
                    {
                        waypoint.m_revision = Int32.Parse(tbRevision.Text);
                        text += "revision, ";
                    }
                    if (tbName.Text != "")
                    {
                        waypoint.m_name = tbName.Text;
                        text += "name, ";
                    }
                    if (tbRadius.Text != "")
                    {
                        waypoint.m_radius = Double.Parse(tbRadius.Text);
                        text += "radius, ";
                    }
                    if (tbLat.Text != "")
                    {
                        waypoint.m_lat = Double.Parse(tbLat.Text);
                    }
                    else
                    {
                        MessageBox.Show("lat는 필수요소 입니다");
                    }
                    if (tbLon.Text != "")
                    {
                        waypoint.m_lon = Double.Parse(tbLon.Text);
                    }
                    else
                    {
                        MessageBox.Show("lon는 필수요소 입니다");
                    }
                    if (tbStarboardXTD.Text != "")
                    {
                        waypoint.m_starboardXTD = Double.Parse(tbStarboardXTD.Text);
                        Ltext += "starboardXTD, ";
                    }
                    if (tbPortsideXTD.Text != "")
                    {
                        waypoint.m_portsideXTD = Double.Parse(tbPortsideXTD.Text);
                        Ltext += "portsideXTD, ";
                    }
                    if (tbSafetyContour.Text != "")
                    {
                        waypoint.m_safetyContour = Double.Parse(tbSafetyContour.Text);
                        Ltext += "safetyContour, ";
                    }
                    if (tbSafetyDepth.Text != "")
                    {
                        waypoint.m_safetyDepth = Double.Parse(tbSafetyDepth.Text);
                        Ltext += "safetyDepth, ";
                    }
                    /*if (tbGeometryType.Text != "")
                    {
                        waypoint.m_geometryType = Double.Parse(tbGeometryType.Text);
                    }*/
                    if (tbPlanSpeedMin.Text != "")
                    {
                        waypoint.m_planSpeedMin = Double.Parse(tbPlanSpeedMin.Text);
                        Ltext += "planSpeedMin, ";
                    }
                    if (tbPlanSpeedMax.Text != "")
                    {
                        waypoint.m_planSpeedMax = Double.Parse(tbPlanSpeedMax.Text);
                        Ltext += "planSpeedMax, ";
                    }
                    if (tbDraughtForward.Text != "")
                    {
                        waypoint.m_draughtForward = Double.Parse(tbDraughtForward.Text);
                        Ltext += "draughtForward, ";
                    }
                    if (tbDraughtAft.Text != "")
                    {
                        waypoint.m_draughtAft = Double.Parse(tbDraughtAft.Text);
                        Ltext += "draughtAft, ";
                    }
                    if (tbStaticUKC.Text != "")
                    {
                        waypoint.m_staticUKC = Double.Parse(tbStaticUKC.Text);
                        Ltext += "staticUKC, ";
                    }
                    if (tbDynamicUKC.Text != "")
                    {
                        waypoint.m_dynamicUKC = Double.Parse(tbDynamicUKC.Text);
                        Ltext += "dynamicUKC, ";
                    }
                    if (tbMasthead.Text != "")
                    {
                        waypoint.m_masthead = Double.Parse(tbMasthead.Text);
                        Ltext += "masthead, ";
                    }
                    if (tbLegReport.Text != "")
                    {
                        waypoint.m_legReport = tbLegReport.Text;
                        Ltext += "legReport, ";
                    }
                    if (tbLegInfo.Text != "")
                    {
                        waypoint.m_legInfo = tbLegInfo.Text;
                        Ltext += "legInfo, ";
                    }
                    if (tbLegNote1.Text != "")
                    {
                        waypoint.m_legNote1 = tbLegNote1.Text;
                        Ltext += "legNote1, ";
                    }
                    if (tbLegNote2.Text != "")
                    {
                        waypoint.m_legNote2 = tbLegNote2.Text;
                        Ltext += "legNote2, ";
                    }
                    if (Ltext != "")
                    {
                        waypoint.hasLeg = true;
                    }

                    WayPointList.Add(waypoint);
                    WPList.BeginUpdate();
                    ListViewItem item;
                    item = new ListViewItem(waypoint.m_id.ToString());
                    item.SubItems.Add(waypoint.m_lat.ToString("F6"));
                    item.SubItems.Add(waypoint.m_lon.ToString("F6"));
                    item.SubItems.Add(text + Ltext);
                    WPList.Items.Add(item);
                    WPList.Columns[3].Width = -2;
                    WPList.EndUpdate();
                }

                else
                {
                    MessageBox.Show("id가 중복되었거나 미입력 상태 입니다");
                }
            //}
            /*catch
            {
                MessageBox.Show("id가 중복되었거나 미입력 상태 입니다");
            }*/

        }

        private void btn_defualtWP_Click_1(object sender, EventArgs e)
        {
            string text = "";
            string Ltext = "";
            bool isOverlap = false;

            waypoint = new Waypoint();
            /*
            if (tbId.Text != "")
            {
                waypoint.m_id = Int32.Parse(tbId.Text);
            }
            else
            {
                MessageBox.Show("id는 필수요소 입니다");
            }
            */
            for(int i = 0; i < WayPointList.Count; i++)
            {
                if(WayPointList[i].m_id == 0)
                {
                    isOverlap = true;
                }
            }
            if (!isOverlap)
            {
                if (tbRevision.Text != "")
                {
                    waypoint.m_revision = Int32.Parse(tbRevision.Text);
                    text += "revision, ";
                }
                if (tbName.Text != "")
                {
                    waypoint.m_name = tbName.Text;
                    text += "name, ";
                }
                if (tbRadius.Text != "")
                {
                    waypoint.m_radius = Double.Parse(tbRadius.Text);
                    text += "radius, ";
                }
                if (tbLat.Text != "")
                {
                    waypoint.m_lat = Double.Parse(tbLat.Text);
                }
                else
                {
                    MessageBox.Show("lat는 필수요소 입니다");
                }
                if (tbLon.Text != "")
                {
                    waypoint.m_lon = Double.Parse(tbLon.Text);
                }
                else
                {
                    MessageBox.Show("lon는 필수요소 입니다");
                }
                if (tbStarboardXTD.Text != "")
                {
                    waypoint.m_starboardXTD = Double.Parse(tbStarboardXTD.Text);
                    Ltext += "starboardXTD, ";
                }
                if (tbPortsideXTD.Text != "")
                {
                    waypoint.m_portsideXTD = Double.Parse(tbPortsideXTD.Text);
                    Ltext += "portsideXTD, ";
                }
                if (tbSafetyContour.Text != "")
                {
                    waypoint.m_safetyContour = Double.Parse(tbSafetyContour.Text);
                    Ltext += "safetyContour, ";
                }
                if (tbSafetyDepth.Text != "")
                {
                    waypoint.m_safetyDepth = Double.Parse(tbSafetyDepth.Text);
                    Ltext += "safetyDepth, ";
                }
                /*if (tbGeometryType.Text != "")
                {
                    waypoint.m_geometryType = Double.Parse(tbGeometryType.Text);
                }*/
                if (tbPlanSpeedMin.Text != "")
                {
                    waypoint.m_planSpeedMin = Double.Parse(tbPlanSpeedMin.Text);
                    Ltext += "planSpeedMin, ";
                }
                if (tbPlanSpeedMax.Text != "")
                {
                    waypoint.m_planSpeedMax = Double.Parse(tbPlanSpeedMax.Text);
                    Ltext += "planSpeedMax, ";
                }
                if (tbDraughtForward.Text != "")
                {
                    waypoint.m_draughtForward = Double.Parse(tbDraughtForward.Text);
                    Ltext += "draughtForward, ";
                }
                if (tbDraughtAft.Text != "")
                {
                    waypoint.m_draughtAft = Double.Parse(tbDraughtAft.Text);
                    Ltext += "draughtAft, ";
                }
                if (tbStaticUKC.Text != "")
                {
                    waypoint.m_staticUKC = Double.Parse(tbStaticUKC.Text);
                    Ltext += "staticUKC, ";
                }
                if (tbDynamicUKC.Text != "")
                {
                    waypoint.m_dynamicUKC = Double.Parse(tbDynamicUKC.Text);
                    Ltext += "dynamicUKC, ";
                }
                if (tbMasthead.Text != "")
                {
                    waypoint.m_masthead = Double.Parse(tbMasthead.Text);
                    Ltext += "masthead, ";
                }
                if (tbLegReport.Text != "")
                {
                    waypoint.m_legReport = tbLegReport.Text;
                    Ltext += "legReport, ";
                }
                if (tbLegInfo.Text != "")
                {
                    waypoint.m_legInfo = tbLegInfo.Text;
                    Ltext += "legInfo, ";
                }
                if (tbLegNote1.Text != "")
                {
                    waypoint.m_legNote1 = tbLegNote1.Text;
                    Ltext += "legNote1, ";
                }
                if (tbLegNote2.Text != "")
                {
                    waypoint.m_legNote2 = tbLegNote2.Text;
                    Ltext += "legNote2, ";
                }
                if (Ltext != "")
                {
                    waypoint.hasLeg = true;
                }
                WayPointList.Add(waypoint);
                WPList.BeginUpdate();
                ListViewItem item;
                item = new ListViewItem(waypoint.m_id.ToString());
                item.SubItems.Add(waypoint.m_lat.ToString("F6"));
                item.SubItems.Add(waypoint.m_lon.ToString("F6"));
                item.SubItems.Add(text + Ltext);
                WPList.Items.Add(item);
                WPList.Items[WayPointList.Count].BackColor = Color.YellowGreen;
                WPList.Columns[3].Width = -2;
                WPList.EndUpdate();
                DefaultIDX = WayPointList.Count - 1;
                hasDef = true;
            }
            else
            {
                MessageBox.Show("이미 DefaultWayPoint가 있습니다.");
            }
        }

        private void btn_Sche_Click_1(object sender, EventArgs e)
        {
            string text = "";
            bool isWPID = false;
            bool isOverlap = false;
            try
            {
                for (int i = 0; i < WayPointList.Count; i++)
                {
                    if (WayPointList[i].m_id == Int32.Parse(tbWaypointID.Text))
                    {
                        isWPID = true;
                    }

                }
                for (int j = 0; j < ScheduleList.Count; j++)
                {
                    if (ScheduleList[j].m_waypointID == Int32.Parse(tbWaypointID.Text))
                    {
                        isOverlap = true;
                    }
                }

                if (isWPID && !isOverlap)
                {
                    schedule = new ScheduleElement();
                    if (tbScheId.Text != "")
                    {
                        schedule.m_scheId = Int32.Parse(tbScheId.Text);
                    }
                    else
                    {
                        MessageBox.Show("ScheduleId는 필수 항목입니다.");
                    }
                    schedule.m_waypointID = Int32.Parse(tbWaypointID.Text);
                    schedule.ID = ScheduleList.Count + 1;

                    if (tbEtd.Text != "")
                    {
                        schedule.m_etd = DateTime.Parse(tbEtd.Text);
                        text += "etd, ";
                    }
                    if (tbEta.Text != "")
                    {
                        schedule.m_eta = DateTime.Parse(tbEta.Text);
                        text += "eta, ";
                    }
                    /*
                    if (tbEtdWindowBefore.Text != "")
                    {
                        schedule.m_etdWindowBefore = (tbEtdWindowBefore.Text);
                        text += "etdWindowBefore, ";
                    }
                    if (tbEtdWindowAfter.Text != "")
                    {
                        schedule.m_etdWindowAfter = (tbEtdWindowAfter.Text);
                        text += "etdWindowAfter, ";
                    }
                    if (tbEtaWindowBefore.Text != "")
                    {
                        schedule.m_etaWindowBefore = (tbEtaWindowBefore.Text);
                        text += "etaWindowBefore, ";
                    }
                    if (tbEtaWindowAfter.Text != "")
                    {
                        schedule.m_etaWindowAfter = (tbEtaWindowAfter.Text);
                        text += "etaWindowAfter, ";
                    }
                    if (tbStay.Text != "")
                    {
                        schedule.m_stay = (tbStay.Text);
                        text += "stay, ";
                    }*/  // 아직 타입을 못 정해준 부분
                    if (tbSpeed.Text != "")
                    {
                        schedule.m_speed = Double.Parse(tbSpeed.Text);
                        text += "speed, ";
                    }
                    if (tbSpeedWindow.Text != "")
                    {
                        schedule.m_speedWindow = Double.Parse(tbSpeedWindow.Text);
                        text += "speedWindow, ";
                    }
                    if (tbWindSpeed.Text != "")
                    {
                        schedule.m_windSpeed = Double.Parse(tbWindSpeed.Text);
                        text += "windSpeed, ";
                    }
                    if (tbWindDirection.Text != "")
                    {
                        schedule.m_windDirection = Double.Parse(tbWindDirection.Text);
                        text += "windDirection, ";
                    }
                    if (tbCurrentSpeed.Text != "")
                    {
                        schedule.m_currentSpeed = Double.Parse(tbCurrentSpeed.Text);
                        text += "currentSpeed, ";
                    }
                    if (tbCurrentDirection.Text != "")
                    {
                        schedule.m_currentDirection = Double.Parse(tbCurrentDirection.Text);
                        text += "currentDirection, ";
                    }
                    if (tbWinLoss.Text != "")
                    {
                        schedule.m_winLoss = Double.Parse(tbWinLoss.Text);
                        text += "winLoss, ";
                    }
                    if (tbWaveLoss.Text != "")
                    {
                        schedule.m_waveLoss = Double.Parse(tbWaveLoss.Text);
                        text += "waveLoss, ";
                    }
                    if (tbTotalLoss.Text != "")
                    {
                        schedule.m_totalLoss = Double.Parse(tbTotalLoss.Text);
                        text += "totalLoss, ";
                    }
                    if (tbRpm.Text != "")
                    {
                        schedule.m_rpm = Int32.Parse(tbRpm.Text);
                        text += "rpm, ";
                    }
                    if (tbPitch.Text != "")
                    {
                        schedule.m_pitch = Int32.Parse(tbPitch.Text);
                        text += "pitch, ";
                    }
                    if (tbFuel.Text != "")
                    {
                        schedule.m_fuel = Double.Parse(tbFuel.Text);
                        text += "fuel, ";
                    }
                    if (tbRelFuelSave.Text != "")
                    {
                        schedule.m_relFuelSave = Double.Parse(tbRelFuelSave.Text);
                        text += "m_relFuelSave, ";
                    }
                    if (tbAbsFuelSave.Text != "")
                    {
                        schedule.m_absFuelSave = Double.Parse(tbAbsFuelSave.Text);
                        text += "absFuelSave, ";
                    }
                    if (tbNote.Text != "")
                    {
                        schedule.m_Note = tbNote.Text;
                        text += "Note, ";
                    }


                    ScheduleList.Add(schedule);

                    scheList.BeginUpdate();
                    ListViewItem item;
                    item = new ListViewItem(schedule.ID.ToString());
                    item.SubItems.Add(schedule.m_scheId.ToString());
                    item.SubItems.Add(schedule.m_waypointID.ToString());
                    item.SubItems.Add(text);
                    scheList.Items.Add(item);
                    scheList.Columns[1].Width = -2;
                    scheList.EndUpdate();
                    Console.WriteLine(ScheduleList[0].m_eta);
                    Console.WriteLine(ScheduleList[0].m_eta.ToString("yyyy-MM-ddTHH:mm:ss"));
                }
                else
                {
                    MessageBox.Show("일치하는 waypointID를 찾을수 없습니다.");
                }
            } catch
            {
                MessageBox.Show("Error");
            }
        }

        private void btn_WPEdit_Click(object sender, EventArgs e)
        {
            string text = "";
            string Ltext = "";
            try
            {
                for (int i = 0; i < WayPointList.Count; i++)
                {
                    if (WayPointList[i].m_id == Int32.Parse(tbId.Text))
                    {
                        if (tbRevision.Text != "")
                        {
                            WayPointList[i].m_revision = Int32.Parse(tbRevision.Text);
                            text += "revision, ";
                        }
                        if (tbName.Text != "")
                        {
                            WayPointList[i].m_name = tbName.Text;
                            text += "name, ";
                        }
                        if (tbRadius.Text != "")
                        {
                            WayPointList[i].m_radius = Double.Parse(tbRadius.Text);
                            text += "radius, ";
                        }
                        if (tbLat.Text != "")
                        {
                            WayPointList[i].m_lat = Double.Parse(tbLat.Text);
                        }
                        else
                        {
                            MessageBox.Show("lat는 필수요소 입니다");
                        }
                        if (tbLon.Text != "")
                        {
                            WayPointList[i].m_lon = Double.Parse(tbLon.Text);
                        }
                        else
                        {
                            MessageBox.Show("lon는 필수요소 입니다");
                        }
                        if (tbStarboardXTD.Text != "")
                        {
                            WayPointList[i].m_starboardXTD = Double.Parse(tbStarboardXTD.Text);
                            Ltext += "starboardXTD, ";
                        }
                        if (tbPortsideXTD.Text != "")
                        {
                            WayPointList[i].m_portsideXTD = Double.Parse(tbPortsideXTD.Text);
                            Ltext += "portsideXTD, ";
                        }
                        if (tbSafetyContour.Text != "")
                        {
                            WayPointList[i].m_safetyContour = Double.Parse(tbSafetyContour.Text);
                            Ltext += "safetyContour, ";
                        }
                        if (tbSafetyDepth.Text != "")
                        {
                            WayPointList[i].m_safetyDepth = Double.Parse(tbSafetyDepth.Text);
                            Ltext += "safetyDepth, ";
                        }
                        /*if (tbGeometryType.Text != "")
                        {
                            waypoint.m_geometryType = Double.Parse(tbGeometryType.Text);
                        }*/
                        if (tbPlanSpeedMin.Text != "")
                        {
                            WayPointList[i].m_planSpeedMin = Double.Parse(tbPlanSpeedMin.Text);
                            Ltext += "planSpeedMin, ";
                        }
                        if (tbPlanSpeedMax.Text != "")
                        {
                            WayPointList[i].m_planSpeedMax = Double.Parse(tbPlanSpeedMax.Text);
                            Ltext += "planSpeedMax, ";
                        }
                        if (tbDraughtForward.Text != "")
                        {
                            WayPointList[i].m_draughtForward = Double.Parse(tbDraughtForward.Text);
                            Ltext += "draughtForward, ";
                        }
                        if (tbDraughtAft.Text != "")
                        {
                            WayPointList[i].m_draughtAft = Double.Parse(tbDraughtAft.Text);
                            Ltext += "draughtAft, ";
                        }
                        if (tbStaticUKC.Text != "")
                        {
                            WayPointList[i].m_staticUKC = Double.Parse(tbStaticUKC.Text);
                            Ltext += "staticUKC, ";
                        }
                        if (tbDynamicUKC.Text != "")
                        {
                            WayPointList[i].m_dynamicUKC = Double.Parse(tbDynamicUKC.Text);
                            Ltext += "dynamicUKC, ";
                        }
                        if (tbMasthead.Text != "")
                        {
                            WayPointList[i].m_masthead = Double.Parse(tbMasthead.Text);
                            Ltext += "masthead, ";
                        }
                        if (tbLegReport.Text != "")
                        {
                            WayPointList[i].m_legReport = tbLegReport.Text;
                            Ltext += "legReport, ";
                        }
                        if (tbLegInfo.Text != "")
                        {
                            WayPointList[i].m_legInfo = tbLegInfo.Text;
                            Ltext += "legInfo, ";
                        }
                        if (tbLegNote1.Text != "")
                        {
                            WayPointList[i].m_legNote1 = tbLegNote1.Text;
                            Ltext += "legNote1, ";
                        }
                        if (tbLegNote2.Text != "")
                        {
                            WayPointList[i].m_legNote2 = tbLegNote2.Text;
                            Ltext += "legNote2, ";
                        }
                        WPList.BeginUpdate();
                        ListViewItem item;
                        item = new ListViewItem(WayPointList[i].m_id.ToString());
                        item.SubItems.Add(WayPointList[i].m_lat.ToString("F6"));
                        item.SubItems.Add(WayPointList[i].m_lon.ToString("F6"));
                        item.SubItems.Add(text + Ltext);
                        WPList.Items[i + 1] = item;
                        if(WayPointList[i].m_id == 0)
                        {
                            WPList.Items[WayPointList.Count].BackColor = Color.YellowGreen;
                        }
                        WPList.EndUpdate();
                    }
                }
            } catch 
            {
                MessageBox.Show("일치하는 id가 없습니다.");
            }

        }

        private void btn_WPDelete_Click(object sender, EventArgs e)
        {
            int IDX = 0;
            for(int i = 0; i < WayPointList.Count ; i++)
            {

                if(tbId.Text != "" && WayPointList[i].m_id == Int32.Parse(tbId.Text))
                {
                   IDX = i;
                   WayPointList.Remove(WayPointList[i]);
                   WPList.Items.RemoveAt(i+1);
                }
            }
        }

        private void btn_ScheEdit_Click(object sender, EventArgs e)
        {
            string text = "";
            string Ltext = "";
            try
            {
                for (int i = 0; i < ScheduleList.Count; i++)
                {
                    if (ScheduleList[i].m_scheId == Int32.Parse(tbScheId.Text) && ScheduleList[i].m_waypointID == Int32.Parse(tbWaypointID.Text))
                    {
                        if (tbScheId.Text != "")
                        {
                            ScheduleList[i].m_scheId = Int32.Parse(tbScheId.Text);
                        }
                        else
                        {
                            MessageBox.Show("ScheduleId는 필수 항목입니다.");
                        }
                        ScheduleList[i].m_waypointID = Int32.Parse(tbWaypointID.Text);

                        if (tbEtd.Text != "")
                        {
                            ScheduleList[i].m_etd = DateTime.Parse(tbEtd.Text);
                            text += "etd, ";
                        }
                        if (tbEta.Text != "")
                        {
                            ScheduleList[i].m_eta = DateTime.Parse(tbEta.Text);
                            text += "eta, ";
                        }
                        /*
                        if (tbEtdWindowBefore.Text != "")
                        {
                            ScheduleList[i].m_etdWindowBefore = (tbEtdWindowBefore.Text);
                            text += "etdWindowBefore, ";
                        }
                        if (tbEtdWindowAfter.Text != "")
                        {
                            ScheduleList[i].m_etdWindowAfter = (tbEtdWindowAfter.Text);
                            text += "etdWindowAfter, ";
                        }
                        if (tbEtaWindowBefore.Text != "")
                        {
                            ScheduleList[i].m_etaWindowBefore = (tbEtaWindowBefore.Text);
                            text += "etaWindowBefore, ";
                        }
                        if (tbEtaWindowAfter.Text != "")
                        {
                            ScheduleList[i].m_etaWindowAfter = (tbEtaWindowAfter.Text);
                            text += "etaWindowAfter, ";
                        }
                        if (tbStay.Text != "")
                        {
                            ScheduleList[i].m_stay = (tbStay.Text);
                            text += "stay, ";
                        }*/  // 아직 타입을 못 정해준 부분
                        if (tbSpeed.Text != "")
                        {
                            ScheduleList[i].m_speed = Double.Parse(tbSpeed.Text);
                            text += "speed, ";
                        }
                        if (tbSpeedWindow.Text != "")
                        {
                            ScheduleList[i].m_speedWindow = Double.Parse(tbSpeedWindow.Text);
                            text += "speedWindow, ";
                        }
                        if (tbWindSpeed.Text != "")
                        {
                            ScheduleList[i].m_windSpeed = Double.Parse(tbWindSpeed.Text);
                            text += "windSpeed, ";
                        }
                        if (tbWindDirection.Text != "")
                        {
                            ScheduleList[i].m_windDirection = Double.Parse(tbWindDirection.Text);
                            text += "windDirection, ";
                        }
                        if (tbCurrentSpeed.Text != "")
                        {
                            ScheduleList[i].m_currentSpeed = Double.Parse(tbCurrentSpeed.Text);
                            text += "currentSpeed, ";
                        }
                        if (tbCurrentDirection.Text != "")
                        {
                            ScheduleList[i].m_currentDirection = Double.Parse(tbCurrentDirection.Text);
                            text += "currentDirection, ";
                        }
                        if (tbWinLoss.Text != "")
                        {
                            ScheduleList[i].m_winLoss = Double.Parse(tbWinLoss.Text);
                            text += "winLoss, ";
                        }
                        if (tbWaveLoss.Text != "")
                        {
                            ScheduleList[i].m_waveLoss = Double.Parse(tbWaveLoss.Text);
                            text += "waveLoss, ";
                        }
                        if (tbTotalLoss.Text != "")
                        {
                            ScheduleList[i].m_totalLoss = Double.Parse(tbTotalLoss.Text);
                            text += "totalLoss, ";
                        }
                        if (tbRpm.Text != "")
                        {
                            ScheduleList[i].m_rpm = Int32.Parse(tbRpm.Text);
                            text += "rpm, ";
                        }
                        if (tbPitch.Text != "")
                        {
                            ScheduleList[i].m_pitch = Int32.Parse(tbPitch.Text);
                            text += "pitch, ";
                        }
                        if (tbFuel.Text != "")
                        {
                            ScheduleList[i].m_fuel = Double.Parse(tbFuel.Text);
                            text += "fuel, ";
                        }
                        if (tbRelFuelSave.Text != "")
                        {
                            ScheduleList[i].m_relFuelSave = Double.Parse(tbRelFuelSave.Text);
                            text += "m_relFuelSave, ";
                        }
                        if (tbAbsFuelSave.Text != "")
                        {
                            ScheduleList[i].m_absFuelSave = Double.Parse(tbAbsFuelSave.Text);
                            text += "absFuelSave, ";
                        }
                        if (tbNote.Text != "")
                        {
                            ScheduleList[i].m_Note = tbNote.Text;
                            text += "Note, ";
                        }
                        scheList.BeginUpdate();
                        ListViewItem item;
                        item = new ListViewItem(ScheduleList[i].ID.ToString());
                        item.SubItems.Add(ScheduleList[i].m_scheId.ToString());
                        item.SubItems.Add(ScheduleList[i].m_waypointID.ToString());
                        item.SubItems.Add(text + Ltext);
                        scheList.Items[i + 1] = item;
                        scheList.EndUpdate();
                    }
                }
            }
            catch
            {
                MessageBox.Show("일치하는 정보가 없습니다.");
            }
        }

        private void btn_ScheDelete_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < ScheduleList.Count; i++)
                {

                    if (tbScheId.Text != "" && ScheduleList[i].m_scheId == Int32.Parse(tbScheId.Text) && tbWaypointID.Text != "" && ScheduleList[i].m_waypointID == Int32.Parse(tbWaypointID.Text))
                    {
                        ScheduleList.Remove(ScheduleList[i]);
                        scheList.Items.RemoveAt(i + 1);
                    }
                }
            } catch
            {
                MessageBox.Show("일치하는 정보가 없습니다.");
            }
        }
    }
}