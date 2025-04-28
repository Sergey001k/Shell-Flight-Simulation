using Godot;
using System;

public partial class Bullet : Node3D
{	
	private Marker3D _BulletMarker;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_BulletMarker = GetNode<Marker3D>("../Cannon/Turret/Barrel/BulletMarker");
		Visible = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// TODO: Aleksio: тут вращается снаряд (было бы круто объединить в 1 rotate)
		//Rotate(-_BulletMarker.GlobalTransform.Basis.X, 0.2f);
		// TODO: Aleksio: тут изменяться угол снаряда
		//Rotate(new Vector3(0,0,1f), 0.5f);
		Vector3 velocity = new Vector3(0.1f,0.1f,0.0f) * (-_BulletMarker.GlobalTransform.Basis.X);
		GlobalPosition += velocity;
		//GD.Print(GlobalPosition);
	}
	
	private void _on_cannon_shot_fired()
	{			
		GlobalPosition = _BulletMarker.GlobalPosition;
		Visible = true;
		Scale = new Vector3(10f,10f,10f);
		Rotation += new Vector3(0f,0f, (float)Math.PI);
	}

}
