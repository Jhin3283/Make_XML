using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Make_XML
{
    public class ScheduleElement
    {
        public int m_waypointID, m_rpm, m_pitch, m_scheId, ID;
        public DateTime m_etd, m_eta;
        public double m_speed, m_windSpeed, m_windDirection, m_currentSpeed, m_currentDirection, m_winLoss, m_waveLoss, m_totalLoss, m_fuel, m_relFuelSave, m_absFuelSave, m_speedWindow;
        public string m_Note;
        // double m_etdWindowBefore, m_etdWindowAfter, m_etaWindowBefore, m_etaWindowAfter // HH.MM 형식이라서 일단 double로 선언하긴 했는데 잘 모르겠음
        // m_stay  // dd.hh.mm 형식인데 뭘로 선언해야할지 모르겠음
        public ScheduleElement()
        {
            m_waypointID = 0;
             m_etd = DateTime.Now;
             m_eta = DateTime.Now;
            // m_etdWindowBefore = 12.20;
            // m_etdWindowAfter = 12.20;
            // m_etaWindowBefore = 12.20;
            // m_etaWindowAfter = 12.20;
            // m_stay = 01.12.20; 
            m_speed = 0f;
            m_speedWindow = 0f;
            m_windSpeed = 0f;
            m_windDirection = 0f;
            m_currentSpeed = 0f;
            m_currentDirection = 0f;
            m_winLoss = 0f;
            m_waveLoss = 0f;
            m_totalLoss = 0f;
            m_rpm = 0;
            m_pitch = 0;
            m_fuel = 0f;
            m_relFuelSave = 0f;
            m_absFuelSave = 0f;
            m_Note = "";
        }
    }
}
