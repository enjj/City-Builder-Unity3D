using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests {
    public class GridStructureTest {

        GridStructure structure;

        [OneTimeSetUp]
        public void Init() {
            structure = new GridStructure(3,100,100);
        }

        [Test]
        public void CalculateGridPositionPasses() {
            Vector3 pos = new Vector3(0, 0, 0);
            Vector3 returnPos = structure.CalculateGridPosition(pos);
            Assert.AreEqual(Vector3.zero, returnPos);
        }

        [Test]
        public void CalculateGridPositionFloatPasses() {
            Vector3 pos = new Vector3(2.9f, 0, 2.9f);
            Vector3 returnPos = structure.CalculateGridPosition(pos);
            Assert.AreEqual(Vector3.zero, returnPos);
        }

        [Test]
        public void CalculateGridPositionFail() {
            Vector3 pos = new Vector3(2.9f, 0, 2.9f);
            Vector3 returnPos = structure.CalculateGridPosition(pos);
            Assert.AreNotEqual(Vector3.one, returnPos);
        }

    }
}
