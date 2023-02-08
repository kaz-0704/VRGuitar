using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XCharts.Runtime;

namespace VRGuitar
{
    public class ChartScript : MonoBehaviour
    {
        [SerializeField] private RadarChart radarChart;

        public int rythm_score
        {
            get { return rythm_score; }
            set { rythm_score = value; }
        }
        public int z_score
        {
            get { return z_score; }
            set { z_score = value; }
        }
        public int y_score
        {
            get { return y_score; }
            set { y_score = value; }
        }
        public int forearm_score
        {
            get { return forearm_score; }
            set { forearm_score = value; }
        }

        void Start()
        {
            radarChart.series[0].RemoveData(0);
            //TitleSet();
            //IndicatorSet();
        }

        //private void TitleSet() //�^�C�g���̕\���ݒ�
        //{
        //    var title = radarChart.GetOrAddChartComponent<Title>();
        //    Debug.Log(title.text);
        //    title.text = "�]���X�R�A";
        //}
        //private void IndicatorSet()
        //{
        //    var coord = radarChart.GetOrAddChartComponent<RadarCoord>();
        //    coord.splitNumber = 4;
        //    coord.indicatorList[0].name = "���Y��";
        //    coord.indicatorList[1].name = "���̂Ђ˂��]";
        //    coord.indicatorList[2].name = "���̕��i";
        //    coord.indicatorList[3].name = "�O�r�̐U�ꕝ";
        //}

        public void ScoreSet(float rythm_score, float z_score, float y_score, float forearm_score)
        {
            Debug.Log("Score Set");
            SerieData radarData = new SerieData();
            radarData.data = new List<double>();
            radarData.data.Add(rythm_score);
            radarData.data.Add(z_score);
            radarData.data.Add(y_score);
            radarData.data.Add(forearm_score);
            radarChart.series[0].AddData(radarData.data);
            radarChart.RefreshChart();
        }
    }
}
