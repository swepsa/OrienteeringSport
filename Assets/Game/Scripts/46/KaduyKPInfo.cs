// информация о всех КП возможных на локации Кадуй
using UnityEngine;
public class KaduyKPInfo : MonoBehaviour {
		
		public KpInfo[] arrayKP=new KpInfo [93]; //на все КП выделяется 89
		public int counterOfArrayKP = 2;

		// структура для инициализации КП
		public struct KpInfo{
				public float x;
				public float y;
				public float z;

				public KpInfo(float x0,float y0,float z0){
						x=x0;
						y=y0;
						z=z0;
				}
		}

		// объявление всех КП
		void Awake () {
				arrayKP [counterOfArrayKP] = new KpInfo (191.6804f,50,207.2171f);counterOfArrayKP++;
				arrayKP [counterOfArrayKP] = new KpInfo (223.9225f,50,233.6737f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (248.8412f,50.82397f,227.346f);counterOfArrayKP++;
				arrayKP [counterOfArrayKP] = new KpInfo (254.6098f,46.05216f,237.0261f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (241.2792f,46.49183f,266.8395f);counterOfArrayKP++;
				arrayKP [counterOfArrayKP] = new KpInfo (229.2253f,48.76178f,277.3337f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (253.3091f,47.74264f,283.0489f);counterOfArrayKP++;
				arrayKP [counterOfArrayKP] = new KpInfo (275.2056f,47.14265f,228.7695f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (281.4073f,50.34207f,237.9803f);counterOfArrayKP++;
				arrayKP [counterOfArrayKP] = new KpInfo (297.0965f,49.88467f,235.5927f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (308.2259f,47.50046f,229.8189f);counterOfArrayKP++;
				arrayKP [counterOfArrayKP] = new KpInfo (292.2087f,52.29063f,251.0098f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (295.5462f,51.23932f,260.0736f);counterOfArrayKP++;
				arrayKP [counterOfArrayKP] = new KpInfo (285.1879f,46.55306f,295.343f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (336.4598f,45.81772f,272.9078f);counterOfArrayKP++;
				arrayKP [counterOfArrayKP] = new KpInfo (307.7733f,47.82177f,281.4051f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (319.6745f,45.51694f,305.374f);counterOfArrayKP++;
				arrayKP [counterOfArrayKP] = new KpInfo (299.8854f,47.2213f,316.2203f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (332.4762f,42.96318f,313.5596f);counterOfArrayKP++;
				arrayKP [counterOfArrayKP] = new KpInfo (337.3172f,419782f,319.3126f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (326.0573f,45.0501f,343.4027f);counterOfArrayKP++;
				arrayKP [counterOfArrayKP] = new KpInfo (334.1212f,45.44891f,361.0405f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (296.7954f,45.56368f,370.317f);counterOfArrayKP++;
				arrayKP [counterOfArrayKP] = new KpInfo (377.2714f,45.27669f,304.4855f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (393.6642f,45.56823f,315.1009f);counterOfArrayKP++;
				arrayKP [counterOfArrayKP] = new KpInfo (411.8023f,45.88114f,293.9706f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (446.5491f,44.55145f,355.2151f);counterOfArrayKP++;
				arrayKP [counterOfArrayKP] = new KpInfo (454.9217f,46.36255f,332.1847f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (453.853f,49.85853f,294.7411f);counterOfArrayKP++;
				arrayKP [counterOfArrayKP] = new KpInfo (455.6527f,49.99405f,284.3789f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (402.436f,46.32493f,228.4976f);counterOfArrayKP++;
				arrayKP [counterOfArrayKP] = new KpInfo (433.5989f,47.50322f,206.9404f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (463.5624f,47.76473f,181.4463f);counterOfArrayKP++;
				arrayKP [counterOfArrayKP] = new KpInfo (418.4169f,47.50046f,161.5479f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (290.1849f,51.76626f,200.0484f);counterOfArrayKP++;
				arrayKP [counterOfArrayKP] = new KpInfo (259.2456f,52.49954f,188.5341f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (199.1798f,51.01325f,196.1728f);counterOfArrayKP++;
				arrayKP [counterOfArrayKP] = new KpInfo (208.878f,52.49954f,178.7716f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (237.8029f,53.75084f,150.883f);counterOfArrayKP++;
				arrayKP [counterOfArrayKP] = new KpInfo (352.8594f,53.70108f,77.77802f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (342.8881f,54.03145f,66.56366f);counterOfArrayKP++;
				arrayKP [counterOfArrayKP] = new KpInfo (465.5905f,50.2896f,117.1593f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (455.9888f,56.40707f,38.01355f);counterOfArrayKP++;
				arrayKP [counterOfArrayKP] = new KpInfo (398.1096f,56.5666f,53.44444f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (376.1421f,56.25038f,36.34396f);counterOfArrayKP++;
				arrayKP [counterOfArrayKP] = new KpInfo (345.1421f,52.75674f,45.27063f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (322.4128f,57.49863f,30.8533f);counterOfArrayKP++;
				arrayKP [counterOfArrayKP] = new KpInfo (316.0671f,55.36666f,42.11383f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (306.8241f,57.46663f,33.02924f);counterOfArrayKP++;
				arrayKP [counterOfArrayKP] = new KpInfo (302.1441f,54.31895f,76.78403f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (264.5726f,56.25038f,51.29242f);counterOfArrayKP++;
				arrayKP [counterOfArrayKP] = new KpInfo (201.1741f,53.4948f,68.319f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (192.745f,58.19931f,49.62518f);counterOfArrayKP++;
				arrayKP [counterOfArrayKP] = new KpInfo (169.0526f,56.50102f,74.14282f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (148.1526f,56.25038f,96.18872f);counterOfArrayKP++;
				arrayKP [counterOfArrayKP] = new KpInfo (95.34793f,57999f,35.25687f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (68.58826f,54.90107f,20.84836f);counterOfArrayKP++;
				arrayKP [counterOfArrayKP] = new KpInfo (57.39297f,55.20209f,36.39847f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (91.32603f,54.18086f,99.87256f);counterOfArrayKP++;
				arrayKP [counterOfArrayKP] = new KpInfo (66.16856f,50.41239f,106.0557f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (166.8696f,5351465f,152.9579f);counterOfArrayKP++;
				arrayKP [counterOfArrayKP] = new KpInfo (124.3604f,51.0335f,147.2165f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (125.1994f,50.71324f,154.4573f);counterOfArrayKP++;
				arrayKP [counterOfArrayKP] = new KpInfo (115.8772f,50.7497f,147.1973f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (102.1451f,52.53313f,143.4397f);counterOfArrayKP++;
				arrayKP [counterOfArrayKP] = new KpInfo (84.7585f,51.20195f,144.3357f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (81.19632f,51.16412f,170.619f);counterOfArrayKP++;
				arrayKP [counterOfArrayKP] = new KpInfo (106.5057f,50,181.404f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (100.8643f,47.65673f,197.4081f);counterOfArrayKP++;
				arrayKP [counterOfArrayKP] = new KpInfo (119.6838f,48.0386f,214.3198f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (104.2355f,50,219.0782f);counterOfArrayKP++;
				arrayKP [counterOfArrayKP] = new KpInfo (83.55133f,48.05444f,214.7738f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (76.55917f,48.6663f,224.4591f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (50.54605f,46.69949f,225.0364f);counterOfArrayKP++;
				arrayKP [counterOfArrayKP] = new KpInfo (47.58752f,47.91414f,236.097f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (20.45001f,50,256.63f);counterOfArrayKP++;
				arrayKP [counterOfArrayKP] = new KpInfo (31.42181f,50,259.8123f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (43.9834f,49.59517f,260.5539f);counterOfArrayKP++;
				arrayKP [counterOfArrayKP] = new KpInfo (28.69269f,48.19305f,286.0114f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (48.47995f,49.94793f,310.7159f);counterOfArrayKP++;
				arrayKP [counterOfArrayKP] = new KpInfo (47.73282f,50,351.8371f);counterOfArrayKP++;					
				arrayKP [counterOfArrayKP] = new KpInfo (75.4781f,45.32513f,316.6458f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (101.2971f,47.50046f,318.0316f);counterOfArrayKP++;
				arrayKP [counterOfArrayKP] = new KpInfo (91.5704f,49.47804f,285.6709f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (126.9891f,50,247.6468f);counterOfArrayKP++;
				arrayKP [counterOfArrayKP] = new KpInfo (152.579f,45.34499f,258.8442f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (147.4599f,50,220.4022f);counterOfArrayKP++;
				arrayKP [counterOfArrayKP] = new KpInfo (142.9816f,50,190.147f);counterOfArrayKP++;	
				arrayKP [counterOfArrayKP] = new KpInfo (159.5035f,50,195.4028f);counterOfArrayKP++;
		}
	
	}