using UnrealBuildTool;

public class Boids_VREditorTarget : TargetRules
{
	public Boids_VREditorTarget(TargetInfo Target) : base(Target)
	{
		DefaultBuildSettings = BuildSettingsVersion.Latest;
		IncludeOrderVersion = EngineIncludeOrderVersion.Latest;
		Type = TargetType.Editor;
		ExtraModuleNames.Add("Boids_VR");
	}
}
