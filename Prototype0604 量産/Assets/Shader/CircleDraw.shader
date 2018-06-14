Shader "Custom/CircleDraw" {	SubShader {
		Tags { "Queue" = "Transparent" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Standard 
		#pragma target 3.0

		struct Input {
			float3 worldPos;
		};

		void surf (Input IN, inout SurfaceOutputStandard o) {
			float dist = distance( fixed3(5.5f,-1,0), IN.worldPos );
			float radius = 15-_Time*100;
			if(  radius < dist ){
				o.Albedo = fixed4(110/255.0, 87/255.0, 139/255.0, 0);
								o.Alpha =0;
			} else {
				o.Albedo = fixed4(255/255.0, 255/255.0, 255/255.0, 1);
				o.Alpha =0;
			}
		}
		ENDCG
	}
	FallBack "Diffuse"
}
