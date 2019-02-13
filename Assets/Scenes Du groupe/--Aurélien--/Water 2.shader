// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Water 2"
{
	Properties
	{
		_ShallowColor("ShallowColor", Color) = (0,0.5267296,0.6132076,1)
		_DeepColor("DeepColor", Color) = (0,0.2982672,0.6132076,1)
		_Waternormal("Water normal", 2D) = "bump" {}
		_Distorsion("Distorsion", Float) = 0
		_WaterDepth("WaterDepth", Float) = 0
		_WaterFalloff("WaterFalloff", Float) = 0
		_SpeedWaterMovement("SpeedWaterMovement", Float) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" }
		Cull Back
		GrabPass{ }
		CGPROGRAM
		#include "UnityStandardUtils.cginc"
		#include "UnityShaderVariables.cginc"
		#include "UnityCG.cginc"
		#pragma target 3.0
		#pragma surface surf Standard alpha:fade keepalpha noshadow 
		struct Input
		{
			float2 uv_texcoord;
			float4 screenPos;
		};

		uniform sampler2D _Waternormal;
		uniform float _SpeedWaterMovement;
		uniform float4 _ShallowColor;
		uniform float4 _DeepColor;
		uniform sampler2D _CameraDepthTexture;
		uniform float _WaterDepth;
		uniform sampler2D _GrabTexture;
		uniform float _Distorsion;
		uniform float _WaterFalloff;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float temp_output_33_0 = ( _Time.y / _SpeedWaterMovement );
			float2 temp_cast_0 = (temp_output_33_0).xx;
			float2 uv_TexCoord9 = i.uv_texcoord * float2( 1,1 ) + float2( 0,0 );
			float2 panner11 = ( uv_TexCoord9 + 1 * _Time.y * temp_cast_0);
			float2 temp_cast_2 = (temp_output_33_0).xx;
			float2 panner10 = ( uv_TexCoord9 + 1 * _Time.y * temp_cast_2);
			float3 temp_output_15_0 = BlendNormals( tex2D( _Waternormal, panner11 ).rgb , UnpackScaleNormal( tex2D( _Waternormal, panner10 ) ,5.0 ) );
			o.Normal = temp_output_15_0;
			float4 ase_screenPos = float4( i.screenPos.xyz , i.screenPos.w + 0.00000000001 );
			float eyeDepth2 = LinearEyeDepth(UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture,UNITY_PROJ_COORD(ase_screenPos))));
			float temp_output_26_0 = ( abs( ( eyeDepth2 - ase_screenPos.w ) ) + _WaterDepth );
			float4 lerpResult8 = lerp( _ShallowColor , _DeepColor , temp_output_26_0);
			float4 ase_screenPosNorm = ase_screenPos / ase_screenPos.w;
			ase_screenPosNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_screenPosNorm.z : ase_screenPosNorm.z * 0.5 + 0.5;
			float2 appendResult18 = (float2(ase_screenPosNorm.x , ase_screenPosNorm.y));
			float4 screenColor17 = tex2D( _GrabTexture, ( float3( ( appendResult18 / ase_screenPosNorm.w ) ,  0.0 ) + ( _Distorsion * temp_output_15_0 ) ).xy );
			float4 lerpResult24 = lerp( lerpResult8 , screenColor17 , saturate( pow( temp_output_26_0 , _WaterFalloff ) ));
			o.Albedo = lerpResult24.rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=15001
1067;92;574;652;1111.444;309.9471;1.777747;False;False
Node;AmplifyShaderEditor.TimeNode;30;-2199.362,-85.84166;Float;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;32;-2159.976,111.628;Float;False;Property;_SpeedWaterMovement;SpeedWaterMovement;6;0;Create;True;0;0;False;0;0;5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;9;-2198.077,-232.4429;Float;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleDivideOpNode;33;-1917.287,-37.78407;Float;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ScreenPosInputsNode;1;-1971.036,428.0834;Float;False;1;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.PannerNode;10;-1728.936,-129.0018;Float;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.PannerNode;11;-1715.936,-284.002;Float;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.ScreenDepthNode;2;-1707.037,408.0836;Float;False;0;True;1;0;FLOAT4;0,0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;14;-1696.936,2.998672;Float;False;Constant;_Float0;Float 0;3;0;Create;True;0;0;False;0;5;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;13;-1474.936,-427.002;Float;True;Property;_TextureSample1;Texture Sample 1;2;0;Create;True;0;0;False;0;None;None;True;0;False;white;Auto;False;Instance;12;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;12;-1474.936,-160.0018;Float;True;Property;_Waternormal;Water normal;2;0;Create;True;0;0;False;0;dd2fd2df93418444c8e280f1d34deeb5;dd2fd2df93418444c8e280f1d34deeb5;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleSubtractOpNode;3;-1561.038,581.0834;Float;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ScreenPosInputsNode;16;-1430.369,-805.8919;Float;False;0;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.BlendNormalsNode;15;-945.6582,-137.6073;Float;False;0;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;23;-1192.191,-612.5798;Float;False;Property;_Distorsion;Distorsion;3;0;Create;True;0;0;False;0;0;0.003;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;18;-1150.11,-782.4926;Float;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.AbsOpNode;4;-1381.038,615.0832;Float;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;25;-1143.364,665.5994;Float;False;Property;_WaterDepth;WaterDepth;4;0;Create;True;0;0;False;0;0;0.9;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;21;-958.3597,-563.5993;Float;False;2;2;0;FLOAT;0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;19;-987.1095,-775.4926;Float;False;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleAddOpNode;26;-1003.364,431.5994;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;28;-877.364,669.5994;Float;False;Property;_WaterFalloff;WaterFalloff;5;0;Create;True;0;0;False;0;0;-3.6;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;22;-856.36,-672.5993;Float;False;2;2;0;FLOAT2;0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.ColorNode;6;-1450.537,383.0187;Float;False;Property;_DeepColor;DeepColor;1;0;Create;True;0;0;False;0;0,0.2982672,0.6132076,1;0,0.2982669,0.6132076,0;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.PowerNode;27;-783.364,506.5994;Float;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;7;-1460.167,202.9755;Float;False;Property;_ShallowColor;ShallowColor;0;0;Create;True;0;0;False;0;0,0.5267296,0.6132076,1;0,0.5247141,0.6132076,0;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ScreenColorNode;17;-712.7568,-393.6741;Float;False;Global;_GrabScreen0;Grab Screen 0;3;0;Create;True;0;0;False;0;Object;-1;False;False;1;0;FLOAT2;0,0;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;8;-698.9374,39.33395;Float;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SaturateNode;29;-647.364,306.5994;Float;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;24;-477.2447,-128.5771;Float;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0.5;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;0,0;Float;False;True;2;Float;ASEMaterialInspector;0;0;Standard;Water 2;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;0;False;0;Transparent;0.5;True;False;0;False;Transparent;;Transparent;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;2;SrcAlpha;OneMinusSrcAlpha;0;Zero;Zero;OFF;OFF;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;0;0;False;0;0;0;False;-1;-1;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;33;0;30;2
WireConnection;33;1;32;0
WireConnection;10;0;9;0
WireConnection;10;2;33;0
WireConnection;11;0;9;0
WireConnection;11;2;33;0
WireConnection;2;0;1;0
WireConnection;13;1;11;0
WireConnection;12;1;10;0
WireConnection;12;5;14;0
WireConnection;3;0;2;0
WireConnection;3;1;1;4
WireConnection;15;0;13;0
WireConnection;15;1;12;0
WireConnection;18;0;16;1
WireConnection;18;1;16;2
WireConnection;4;0;3;0
WireConnection;21;0;23;0
WireConnection;21;1;15;0
WireConnection;19;0;18;0
WireConnection;19;1;16;4
WireConnection;26;0;4;0
WireConnection;26;1;25;0
WireConnection;22;0;19;0
WireConnection;22;1;21;0
WireConnection;27;0;26;0
WireConnection;27;1;28;0
WireConnection;17;0;22;0
WireConnection;8;0;7;0
WireConnection;8;1;6;0
WireConnection;8;2;26;0
WireConnection;29;0;27;0
WireConnection;24;0;8;0
WireConnection;24;1;17;0
WireConnection;24;2;29;0
WireConnection;0;0;24;0
WireConnection;0;1;15;0
ASEEND*/
//CHKSM=D65D8DFC2D34135B4636B3BA520C498578769E18