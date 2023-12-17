Shader "Custom/SineWaveShader"
{
    Properties
    {
        _Amplitude("Amplitude", Range(0, 1)) = 0.5
        _Frequency("Frequency", Range(0, 10)) = 1.0
        _Speed("Speed", Range(0, 10)) = 1.0
    }

        SubShader
    {
        Tags { "Queue" = "Transparent" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
            };

            float _Amplitude;
            float _Frequency;
            float _Speed;

            v2f vert(appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float time = _Time.y * _Speed;
                float value = _Amplitude * sin(2 * 3.14159 * _Frequency * time - 2 * 3.14159 * i.vertex.x);
                return fixed4(value, value, value, 1.0);
            }
            ENDCG
        }
    }
}