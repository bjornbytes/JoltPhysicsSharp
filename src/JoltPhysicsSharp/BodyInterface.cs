// Copyright � Amer Koleci and Contributors.
// Licensed under the MIT License (MIT). See LICENSE in the repository root for more information.

using System.Numerics;
using static JoltPhysicsSharp.JoltApi;

namespace JoltPhysicsSharp;

public readonly struct BodyInterface : IEquatable<BodyInterface>
{
    public BodyInterface(IntPtr handle) { Handle = handle; }
    public IntPtr Handle { get; }
    public bool IsNull => Handle == IntPtr.Zero;
    public static BodyInterface Null => new(IntPtr.Zero);
    public static implicit operator BodyInterface(IntPtr handle) => new(handle);
    public static bool operator ==(BodyInterface left, BodyInterface right) => left.Handle == right.Handle;
    public static bool operator !=(BodyInterface left, BodyInterface right) => left.Handle != right.Handle;
    public static bool operator ==(BodyInterface left, IntPtr right) => left.Handle == right;
    public static bool operator !=(BodyInterface left, IntPtr right) => left.Handle != right;
    public bool Equals(BodyInterface other) => Handle == other.Handle;

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is BodyInterface handle && Equals(handle);

    /// <inheritdoc/>
    public override int GetHashCode() => Handle.GetHashCode();

    public Body CreateBody(BodyCreationSettings settings)
    {
        IntPtr bodyHandle = JPH_BodyInterface_CreateBody(Handle, settings.Handle);
        return new Body(bodyHandle);
    }

    public BodyID CreateAndAddBody(BodyCreationSettings settings, ActivationMode activationMode)
    {
        return new(JPH_BodyInterface_CreateAndAddBody(Handle, settings.Handle, activationMode));
    }

    public Body CreateBodyWithID(in BodyID bodyID, BodyCreationSettings settings)
    {
        IntPtr bodyHandle = JPH_BodyInterface_CreateBodyWithID(Handle, bodyID, settings.Handle);
        return new Body(bodyHandle);
    }

    public void DestroyBody(in BodyID bodyID)
    {
        JPH_BodyInterface_DestroyBody(Handle, bodyID);
    }

    public void AddBody(in BodyID bodyID, ActivationMode activationMode)
    {
        JPH_BodyInterface_AddBody(Handle, bodyID, activationMode);
    }

    public void AddBody(in Body body, ActivationMode activationMode)
    {
        JPH_BodyInterface_AddBody(Handle, body.ID, activationMode);
    }

    public void RemoveBody(in BodyID bodyID)
    {
        JPH_BodyInterface_RemoveBody(Handle, bodyID);
    }

    public void SetLinearVelocity(in Body body, in Vector3 velocity)
    {
        JPH_BodyInterface_SetLinearVelocity(Handle, body.ID, velocity);
    }

    public void SetLinearVelocity(in BodyID bodyID, in Vector3 velocity)
    {
        JPH_BodyInterface_SetLinearVelocity(Handle, bodyID, velocity);
    }

    public Vector3 GetLinearVelocity(in BodyID bodyID)
    {
        JPH_BodyInterface_GetLinearVelocity(Handle, bodyID, out Vector3 velocity);
        return velocity;
    }

    public void GetLinearVelocity(in BodyID bodyID, out Vector3 velocity)
    {
        JPH_BodyInterface_GetLinearVelocity(Handle, bodyID, out velocity);
    }

    public Vector3 GetCenterOfMassPosition(in BodyID bodyID)
    {
        JPH_BodyInterface_GetCenterOfMassPosition(Handle, bodyID, out Vector3 velocity);
        return velocity;
    }

    public void GetCenterOfMassPosition(in BodyID bodyID, out Vector3 velocity)
    {
        JPH_BodyInterface_GetCenterOfMassPosition(Handle, bodyID, out velocity);
    }

    public MotionType GetMotionType(in BodyID bodyID)
    {
        return JPH_BodyInterface_GetMotionType(Handle, bodyID);
    }

    public void SetMotionType(in BodyID bodyID, MotionType motionType, ActivationMode activationMode)
    {
        JPH_BodyInterface_SetMotionType(Handle, bodyID, motionType, activationMode);
    }

    public bool IsActive(in BodyID bodyID) => JPH_BodyInterface_IsActive(Handle, bodyID);
    public bool IsAdded(in BodyID bodyID) => JPH_BodyInterface_IsAdded(Handle, bodyID);
}