using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Make_XML
{
    public class Waypoint
    {
        Leg leg = new Leg();
        Position position = new Position();
        public int m_id, m_revision;
        public string m_name;
        public double m_radius;
        public (double, double) m_position;
        public double m_lat, m_lon;
        public double m_starboardXTD, m_portsideXTD, m_safetyContour, m_safetyDepth, m_planSpeedMin, m_planSpeedMax, m_draughtForward, m_draughtAft, m_staticUKC,
            m_dynamicUKC, m_masthead;
        public string m_legReport, m_legInfo, m_legNote1, m_legNote2;
        public bool hasLeg;
        // string [] m_geometryType;
        public Waypoint()
        {
            m_id = 0; // 고유 식별자 , Mandatory
            m_revision = 0; // 웨이포인트 수정 , Option
            m_name = "Waypoint0"; // 웨이포인트 이름 , Option
            m_radius = 0f; // 회전 반지름 , Option
            // m_position = (0f, 0f); // 지리적 지점 , Mandatory
            // string[] m_Leg // Leg 속성 , Mandatory , 첫 웨이포인트에서는 Optional
            m_lat = position.m_lat;
            m_lon = position.m_lon;
            /*m_starboardXTD = leg.m_starboardXTD;
            m_portsideXTD = leg.m_portsideXTD;
            m_safetyDepth = leg.m_safetyDepth;
            // m_geometryType = leg.m_geometryType;
            m_planSpeedMin = leg.m_planSpeedMin;
            m_planSpeedMax = leg.m_planSpeedMax;
            m_draughtForward = leg.m_draughtForward;
            m_draughtAft =leg.m_draughtAft;
            m_staticUKC = leg.m_staticUKC;
            m_dynamicUKC = leg.m_dynamicUKC;
            m_masthead = leg.m_masthead;
            m_legReport = leg.m_legReport;
            m_legInfo = leg.m_legInfo;
            m_legNote1 = leg.m_legNote1;
            m_legNote2 = leg.m_legNote2;
            */
            hasLeg = false;
        }
    }
    public class Position
    {
        public double m_lat, m_lon;
        public Position()
        {
            m_lat = 0f; // 위도 , Mandatory
            m_lon = 0f; // 경도 , Mandatory
        }
    }
    public class Leg
    {
        public double m_starboardXTD, m_portsideXTD, m_safetyContour, m_safetyDepth, m_planSpeedMin, m_planSpeedMax, m_draughtForward, m_draughtAft, m_staticUKC,
            m_dynamicUKC, m_masthead;
        public string m_legReport, m_legInfo, m_legNote1, m_legNote2;
        // string [] m_geometryType; // Format에 Enumeration으로 열거라고 되있는데 어떻게 처리해야할지 잘 모르겠음.
        public Leg()
        {
            m_starboardXTD = 0f; // 우현 XTD, Option
            m_portsideXTD = 0f; // 포트사이드 XTD, Option
            m_safetyContour = 0f; // 계획된 안전 등고선, Option
            m_safetyDepth = 0f; // 계획된 안전 깊이, Option
            // m_geometryType = []; // leg의 기하학 유형, Option
            m_planSpeedMin = 0f; // 최저 순항 속도, Option
            m_planSpeedMax = 0f; // 최고 허용 속도, Option
            m_draughtForward = 0f; // 정적 드래프트 포워드, Option
            m_draughtAft = 0f; // 정적 드래프트 후미, Option
            m_staticUKC = 0f; // Leg의 최소 UKC, Option
            m_dynamicUKC = 0f; // Leg의 최소 동적 UKC, Option
            m_masthead = 0f; // masthead의 높이 , Option
            m_legReport = ""; // 보고정보, Option
            m_legInfo = ""; // Nice to know, Option
            m_legNote1 = ""; // ETA/ETD에 관한 참고 사항, Option
            m_legNote2 = ""; // 현지 비고, Option
        }
    }
    public class Extension
    {
        public string m_manufacturer, m_name, m_version;

        public Extension()
        {
            m_manufacturer = ""; // 고유한 공급업체 식별자
            m_name = ""; // 확장명
            m_version = ""; // 확장 버전
        }
    }
}
