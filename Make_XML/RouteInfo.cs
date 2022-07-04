using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Make_XML
{
    public class RouteInfo
    {
        public string m_routeName, m_routeAuthor, m_routeStatus, m_vesselName, m_vesselVoyage, m_optimizationMethod, m_routeChangesHistory;
        public int m_vesselDisplacement, m_vesselCargo, m_vesselMMSI, m_vesselIMO;
        public double m_vesselGM, m_vesselMaxRoll, m_vesselMaxWave, m_vesselMax_Wind, m_vesselSpeedMax, m_vesselServiceMin, m_vesselServiceMax;
        // ISO 8601 m_validityPeriodStart, m_validityPeriodStop;    // ISO 8601이 날짜 형식인데 format 지정해야됨

        public RouteInfo()
        {
            /*
            m_routeName = "AROUNDtheSKAGEN"; //루트의 이름, Mandatory
            m_routeAuthor = "Lee"; // 루트 작성자, Option
            m_routeStatus = "No Problem"; // 루트 상태, Option
            //m_validityPeriodStart = ""; //유효 기간 시작, Option
            //m_validityPeriodStop = ""; //유효 기간 정지, Option
            m_vesselName = "ACME"; //배의 이름, Option
            m_vesselMMSI = 123456789; //해상이동업무식별번호 숫자 9자리, Option
            m_vesselIMO = 1234567; // 선박의 IMO번호 숫자 7자리, Option
            m_vesselVoyage = "3회"; // 선박의 항해 횟수, Option
            m_vesselDisplacement = 0; // 선박 변위, Option
            m_vesselCargo = 0; // 선박의 화물, Option
            m_vesselGM = 0f; // 메타 중심높이 xx.xx , Option
            m_optimizationMethod = "Use rian tech"; // 최적화 방법, Option
            m_vesselMaxRoll = 0f; // 선박의 허용된 최대 Roll 각도 xx, Option
            m_vesselMaxWave = 0f; // 선박의 유의파도 높이 제한 xx.x, Option
            m_vesselMax_Wind = 0f; // 선박의 최대 풍속 제한 xx.x, Option
            m_vesselSpeedMax = 0f; // 선박의 최대 속도 xx.x, Option
            m_vesselServiceMin = 0f; // 선박의 선호하는 window 서비스 속도 최소 xx.x, Option
            m_vesselServiceMax = 0f; // 선박의 선호하는 window 서비스 속도 최대 xx.x, Option
            m_routeChangesHistory = "Wind,Lee"; // 경로변경 원인, 발신자 및 이유, Option
            */
        }
    }

}
