﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vsite.Pood.BouncingBall;

namespace Vsite.Pood.BouncingBallTests
{
    [TestClass]
    public class TrajectoryTest
    {
        [TestMethod] // želim izračunati na osnovu početne točke i vremena intervala da neku početnu točku
        public void Trajectory_GetNewPositionReturnsNewPointForVerticalMovement() //na početku ime klase onoga što se testira pa _ pa naziv metode
        {
            Velocity v = new Velocity(1, Math.PI / 2); //Math.PI/2) bi trebala bit vertikala
            PointD p1 = new Vsite.Pood.BouncingBall.PointD(1, 0);
            DateTime t1 = DateTime.Now;
            Trajectory t = new BouncingBall.Trajectory(v, p1, t1);
            PointD p2 = t.GetNewPosition(t1 + TimeSpan.FromSeconds(5));
            Assert.AreEqual(1, p2.X, 1e-5); //definiramo dozvoljenu pogrešku zbog double usporedbe 1e-5))
            Assert.AreEqual(5, p2.Y, 1e-5);
        }

        [TestMethod]
        public void Trajectory_GetNewPositionReturnsNewPointForHorizontalMovement()
        {
            Velocity v = new Velocity(2, 0); // 0 je horizontala
            PointD p1 = new Vsite.Pood.BouncingBall.PointD(1, 1);
            DateTime t1 = DateTime.Now;
            Trajectory t = new BouncingBall.Trajectory(v, p1, t1);
            PointD p2 = v.GetNewPosition(p1, 2);
            Assert.AreEqual(5, p2.X, 1e-5); //definiramo dozvoljenu pogrešku zbog double usporedbe 1e-5))
            Assert.AreEqual(1, p2.Y, 1e-5);
        }

        [TestMethod]
        public void Trajectory_GetNewPositionReturnsNewPointForVerticalMovementDown()
        {
            Velocity v = new Velocity(1, -Math.PI / 2); // je verzticala dolje  -Math.PI / 2)
            PointD p1 = new Vsite.Pood.BouncingBall.PointD(3, 8);
            DateTime t1 = DateTime.Now;
            Trajectory t = new BouncingBall.Trajectory(v, p1, t1);
            PointD p2 = v.GetNewPosition(p1, 5);
            Assert.AreEqual(3, p2.X, 1e-5); //definiramo dozvoljenu pogrešku zbog double usporedbe 1e-5))
            Assert.AreEqual(3, p2.Y, 1e-5);
        }


        [TestMethod]
        public void Trajectory_GetNewPositionReturnsNewPointForHorizontalMovementLeft()
        {
            Velocity v = new Velocity(2, Math.PI); // )Math.PI je lijevo
            PointD p1 = new Vsite.Pood.BouncingBall.PointD(10, 2);
            DateTime t1 = DateTime.Now;
            Trajectory t = new BouncingBall.Trajectory(v, p1, t1);
            PointD p2 = t.GetNewPosition(t1 + TimeSpan.FromSeconds(4));
            Assert.AreEqual(2, p2.X, 1e-5); //definiramo dozvoljenu pogrešku zbog double usporedbe 1e-5))
            Assert.AreEqual(2, p2.Y, 1e-5);
        }

        [TestMethod]
        public void Trajectory_GetNewPositionReturnsNewPointForInclinedMovementAt45Deg()
        {
            Velocity v = new Velocity(1, Math.PI / 4); // Math.PI/4 )Math.PI je dijagonalno desno
            PointD p1 = new Vsite.Pood.BouncingBall.PointD(0, 0);
            DateTime t1 = DateTime.Now;
            Trajectory t = new BouncingBall.Trajectory(v, p1, t1);
            PointD p2 = t.GetNewPosition(t1 + TimeSpan.FromSeconds(2));
            Assert.AreEqual(Math.Sqrt(2), p2.X, 1e-5); //definiramo dozvoljenu pogrešku zbog double usporedbe 1e-5))
            Assert.AreEqual(Math.Sqrt(2), p2.Y, 1e-5);
        }


        [TestMethod]
        public void Trajectory_GetNewPositionReturnsNewPointForInclinedMovementAtSomeAngle()
        {
            Velocity v = new Velocity(1, Math.Atan(3.0 / 4.0));
            PointD p1 = new Vsite.Pood.BouncingBall.PointD(0, 0);
            DateTime t1 = DateTime.Now;
            Trajectory t = new BouncingBall.Trajectory(v, p1, t1);
            PointD p2 = t.GetNewPosition(t1 + TimeSpan.FromSeconds(5));
            Assert.AreEqual(4, p2.X, 1e-5);
            Assert.AreEqual(3, p2.Y, 1e-5);
        }
    }
}