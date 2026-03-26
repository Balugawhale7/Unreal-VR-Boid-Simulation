using UnrealBuildTool;

public class Boids_VRServerTarget : TargetRules
{
	public Boids_VRServerTarget(TargetInfo Target) : base(Target)
	{
		DefaultBuildSettings = BuildSettingsVersion.Latest;
		IncludeOrderVersion = EngineIncludeOrderVersion.Latest;
		Type = TargetType.Server;
		ExtraModuleNames.Add("Boids_VR");
	}
}
