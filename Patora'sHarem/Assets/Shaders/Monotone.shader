Shader "Custom/Monotone" {
	Properties {
		_MainTex ("Albedo (RGB)", 2D) = "" {}
	}
	SubShader {
		Pass{
			CGPROGRAM
			#include "UnityCG.cginc"

			#pragma vertex vert_img
			#pragma fragment frag

			sampler2D _MainTex;

			fixed4 frag(v2f_img i):COLOR{
				fixed4 c = tex2D(_MainTex,i.uv);
				float gray = c.r * 0.2126 + c.g * 0.7152 + c.b * 0.0722;
				c.rag = fixed3(gray,gray,gray);
				return c;
			}

			ENDCG
		}
		
	}
	//FallBack "Diffuse"
}
