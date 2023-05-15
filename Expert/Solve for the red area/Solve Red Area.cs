// This problem went viral in China, spreading on Weibo. The problem is to solve for the area shown in red between the semicircle and the rectangle’s diagonal.

// Create a function that takes a number r as an the length of the side and returns the area rounded to the nearest thousandth.

using System;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;

public class RedArea
{
    public float raduis = 1;


}

public interface iFunction
{
    public float Evaluate(float x);
    public float Integrate(float start, float end);
}

public class LinearFunction : iFunction
{
    readonly float m;
    readonly float c;

    public LinearFunction(float m, float c)
    {
        this.m = m;
        this.c = c;
    }
    public float Evaluate(float x)
    {
        return m*x + c;
    }

    public float Integrate(float start, float end)
    {
        return (m*end*end)/2 - (m*start*start)/2;
    }
}

public class CircularFunction : iFunction
{
    readonly float raduis;

    readonly Vector2 centre;

    readonly bool upperhalf;


    public CircularFunction(float radius, Vector2 centre, bool upperhalf = true)
    {
        this.raduis = radius;
        this.centre = centre;
        this.upperhalf = upperhalf;
    }
    public float Evaluate(float x)
    {
        if ( upperhalf )
        {
            return MathF.Sqrt((raduis*raduis)-(x-centre.X)*(x-centre.X)) + centre.Y;
        } else 
        {
            return MathF.Sqrt((raduis*raduis)-(x-centre.X)*(x-centre.X)) * -1 + centre.Y;
        }
    }

    public float Integrate(float start, float end)
    {
        if (upperhalf)
        {

        } else 
        {
            
        }
    }
}