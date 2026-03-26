using UnrealBuildTool;

public class Boids_VRTarget : TargetRules
{
	public Boids_VRTarget(TargetInfo Target) : base(Target)
	{
		DefaultBuildSettings = BuildSettingsVersion.Latest;
		IncludeOrderVersion = EngineIncludeOrderVersion.Latest;
		Type = TargetType.Game;
		ExtraModuleNames.Add("Boids_VR");
	}
}
