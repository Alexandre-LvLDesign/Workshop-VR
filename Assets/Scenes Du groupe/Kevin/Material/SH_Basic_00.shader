// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "New AmplifyShader"
{
	Properties
	{
		_TableLP_lambert1_BaseColor("Table LP_lambert1_BaseColor", 2D) = "white" {}
		_TableLP_lambert1_Metallic("Table LP_lambert1_Metallic", 2D) = "white" {}
		_TableLP_lambert1_Normal("Table LP_lambert1_Normal", 2D) = "bump" {}
		_TableLP_lambert1_Roughness("Table LP_lambert1_Roughness", 2D) = "white" {}
		_Float0("Float 0", Range( 0 , 1)) = 1
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" }
		Cull Back
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _TableLP_lambert1_Normal;
		uniform float4 _TableLP_lambert1_Normal_ST;
		uniform sampler2D _TableLP_lambert1_BaseColor;
		uniform float4 _TableLP_lambert1_BaseColor_ST;
		uniform sampler2D _TableLP_lambert1_Metallic;
		uniform float4 _TableLP_lambert1_Metallic_ST;
		uniform float _Float0;
		uniform sampler2D _TableLP_lambert1_Roughness;
		uniform float4 _TableLP_lambert1_Roughness_ST;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_TableLP_lambert1_Normal = i.uv_texcoord * _TableLP_lambert1_Normal_ST.xy + _TableLP_lambert1_Normal_ST.zw;
			o.Normal = UnpackNormal( tex2D( _TableLP_lambert1_Normal, uv_TableLP_lambert1_Normal ) );
			float2 uv_TableLP_lambert1_BaseColor = i.uv_texcoord * _TableLP_lambert1_BaseColor_ST.xy + _TableLP_lambert1_BaseColor_ST.zw;
			o.Albedo = tex2D( _TableLP_lambert1_BaseColor, uv_TableLP_lambert1_BaseColor ).rgb;
			float2 uv_TableLP_lambert1_Metallic = i.uv_texcoord * _TableLP_lambert1_Metallic_ST.xy + _TableLP_lambert1_Metallic_ST.zw;
			o.Metallic = ( tex2D( _TableLP_lambert1_Metallic, uv_TableLP_lambert1_Metallic ) * _Float0 ).r;
			float2 uv_TableLP_lambert1_Roughness = i.uv_texcoord * _TableLP_lambert1_Roughness_ST.xy + _TableLP_lambert1_Roughness_ST.zw;
			o.Smoothness = ( 1.0 - tex2D( _TableLP_lambert1_Roughness, uv_TableLP_lambert1_Roughness ) ).r;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=15401
82;277;1906;782;2369.371;638.3371;1.686086;True;True
Node;AmplifyShaderEditor.SamplerNode;2;-1375.152,37.09337;Float;True;Property;_TableLP_lambert1_Metallic;Table LP_lambert1_Metallic;1;0;Create;True;0;0;False;0;e316666478b37434fb7da2f3b0ae9ff3;e316666478b37434fb7da2f3b0ae9ff3;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;6;-1344.941,237.0325;Float;False;Property;_Float0;Float 0;4;0;Create;True;0;0;False;0;1;0.9;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;4;-748.4843,261.1341;Float;True;Property;_TableLP_lambert1_Roughness;Table LP_lambert1_Roughness;3;0;Create;True;0;0;False;0;fb08c7b73a39c614a99a88202ebd91ce;fb08c7b73a39c614a99a88202ebd91ce;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;9;-306.7095,120.7328;Float;False;Constant;_Float1;Float 1;5;0;Create;True;0;0;False;0;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;10;-322.4631,-285.9449;Float;False;Constant;_Color0;Color 0;5;0;Create;True;0;0;False;0;0,0,0,0;0,0,0,0;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;7;-986.9033,41.96365;Float;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;3;-858.8814,-170.7128;Float;True;Property;_TableLP_lambert1_Normal;Table LP_lambert1_Normal;2;0;Create;True;0;0;False;0;48b14b763bc7afb4887b91973824346f;48b14b763bc7afb4887b91973824346f;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;1;-871.8693,-352.5432;Float;True;Property;_TableLP_lambert1_BaseColor;Table LP_lambert1_BaseColor;0;0;Create;True;0;0;False;0;4636a712acb905342a8893f18ab54a6d;4636a712acb905342a8893f18ab54a6d;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.OneMinusNode;8;-278.5447,281.5297;Float;False;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;-8.117425,0;Float;False;True;2;Float;ASEMaterialInspector;0;0;Standard;New AmplifyShader;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;-1;False;-1;-1;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;7;0;2;0
WireConnection;7;1;6;0
WireConnection;8;0;4;0
WireConnection;0;0;1;0
WireConnection;0;1;3;0
WireConnection;0;3;7;0
WireConnection;0;4;8;0
ASEEND*/
//CHKSM=76F2F5BD4B29885D6DC2C0FAE0E3890C94A564F2