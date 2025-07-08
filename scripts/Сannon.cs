using Godot;
using System;

public partial class Сannon : Node3D
{	
	public Camera3D _MainCamera;
	private Marker3D _FlashMarker;
	private GpuParticles3D _Flash;
	
	public Marker3D _BulletMarker;
	public Bullet _bullet;
	public Camera3D _BulletCamera;
	
	[Signal]
	public delegate void ShotFiredEventHandler();

	public override void _Ready()
	{
		var ExplosionScene = ResourceLoader.Load<PackedScene>("res://scenes/explosion.tscn").Instantiate();
		AddChild(ExplosionScene);
		_FlashMarker = GetNode<Marker3D>("../Cannon/Turret/Barrel/FlashMarker");
		
		_BulletMarker = GetNode<Marker3D>("../Cannon/Turret/Barrel/BulletMarker");
		_bullet = GetNode<Bullet>("../Bullet");
		_BulletCamera = GetNode<Camera3D>("../Bullet/BulletCamera");
		_MainCamera = GetNode<Camera3D>("../Camera3D");
		
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
		
		// 2025-04-28 Aleksio: Пробую создать снаряд
		_bullet.GlobalTransform = _BulletMarker.GlobalTransform;
		
		_MainCamera.Current = false;
		_BulletCamera.Current = true;
		_BulletCamera.GlobalPosition = _bullet.GlobalPosition + new Vector3(-1.5f, -2, 0);
		_BulletCamera.LookAt(_bullet.GlobalPosition, new Vector3(0, -90f, -(float)Math.PI/2));
		
	}
	
}
