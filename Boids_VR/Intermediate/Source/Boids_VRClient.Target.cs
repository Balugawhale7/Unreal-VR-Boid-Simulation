using UnrealBuildTool;

public class Boids_VRClientTarget : TargetRules
{
	public Boids_VRClientTarget(TargetInfo Target) : base(Target)
	{
		DefaultBuildSettings = BuildSettingsVersion.Latest;
		IncludeOrderVersion = EngineIncludeOrderVersion.Latest;
		Type = TargetType.Client;
		ExtraModuleNames.Add("Boids_VR");
	}
}
