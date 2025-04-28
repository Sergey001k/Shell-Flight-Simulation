using Godot;
using System;

public partial class Сannon : Node3D
{	
	private Marker3D _FlashMarker;
	private GpuParticles3D _Flash;
	
	[Signal]
	public delegate void ShotFiredEventHandler();

	public override void _Ready()
	{
		var ExplosionScene = ResourceLoader.Load<PackedScene>("res://scenes/explosion.tscn").Instantiate();
		AddChild(ExplosionScene);
		_FlashMarker = GetNode<Marker3D>("../Cannon/Turret/Barrel/FlashMarker");
		_Flash = ExplosionScene.GetNode<GpuParticles3D>("Explosion2");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{	
		
	}
	
	private void _on_shot_button_pressed()
	{
		EmitSignal(SignalName.ShotFired);
	}
	
	private void _on_shot_fired()
	{	
		_Flash.GlobalPosition = _FlashMarker.Position;
		GD.Print(_Flash.GlobalPosition);
		_Flash.Visible = true;
		_Flash.Emitting = true;
	}
	
}
