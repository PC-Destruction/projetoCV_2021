import random

from panda3d.core import loadPrcFile
from panda3d.core import *
from panda3d.core import Material
loadPrcFile("config.prc")
import introcs
from direct.showbase.ShowBase import ShowBase
from direct.interval.LerpInterval import LerpPosInterval
from direct.interval.IntervalGlobal import *
from direct.task import Task
import os, sys
import math
import time

class MyGame(ShowBase):

    def __init__(self):
        ShowBase.__init__(self)
        self.inRoom = None
        # Get the location of the 'py' file I'm running:
        self.mydir = os.path.abspath(sys.path[0])
        # convert to panda's specific notation
        self.mydir = Filename.fromOsSpecific(self.mydir).getFullpath()
        self.setBackgroundColor(0,0,0)

        self.mapModel = self.loader.loadModel(self.mydir + "/Models/Map/MapModel.bam")
        self.mapModel.setPos(0, 0, 0)
        self.mapModel.setScale(20.0,20.0,20.0)
        self.mapModel.reparentTo(self.render)

        alight = AmbientLight('alight')
        alight.setColor((0.01, 0.01, 0.01, 0.2))
        alnp = self.render.attachNewNode(alight)
        self.render.setLight(alnp)

        plight = PointLight('plight')
        plight.setColor((0.5, 0.5, 0.5, 0.01))
        plnp = self.render.attachNewNode(plight)
        plnp.setPos(10, 20, 0)
        self.render.setLight(plnp)

        #self.render.setShaderAuto()

        self.disableMouse()
        
        #self.useDrive()
        #self.useTrackball()
        self.camLens.set_fov(100)
        self.camera.setPos(19.28, 3.40, 0)
        self.camera.setH(89)

        def goBackToHall():
            if self.inRoom:
                self.inRoom = None
                return self.camera.posInterval(1.0, Point3(self.camera.getX(), 3.40, 0))
            return None 
        def moveToRoomA():
            myInterval1 = self.camera.posInterval(1.0, Point3(-5.0, 3.40, 0))
            myInterval2 = self.camera.hprInterval(2.0, Vec3(180, 0, 0))
            myInterval3 = self.camera.posInterval(4.0, Point3(-5.0, -40, 0))
            mySequence = Sequence()
            if self.inRoom:
                mySequence.append(goBackToHall())
            mySequence.append(myInterval1)
            mySequence.append(myInterval3)
            mySequence.start()
            mySequence2 = Sequence(myInterval2)
            mySequence2.start()
            self.inRoom = "A"
        def moveToRoomB():
            myInterval1 = self.camera.posInterval(1.0, Point3(-60.0, 3.40, 0))
            myInterval2 = self.camera.hprInterval(2.0, Vec3(180, 0, 0))
            myInterval3 = self.camera.posInterval(4.0, Point3(-60.0, -40, 0))
            mySequence = Sequence()
            if self.inRoom:
                mySequence.append(goBackToHall())
            mySequence.append(myInterval1)
            mySequence.append(myInterval3)
            mySequence.start()
            mySequence2 = Sequence(myInterval2)
            mySequence2.start()
            self.inRoom = "B"
        def moveToRoomC():
            myInterval1 = self.camera.posInterval(1.0, Point3(-115.0, 3.40, 0))
            myInterval2 = self.camera.hprInterval(2.0, Vec3(180, 0, 0))
            myInterval3 = self.camera.posInterval(4.0, Point3(-115.0, -40, 0))
            mySequence = Sequence()
            if self.inRoom:
                mySequence.append(goBackToHall())
            mySequence.append(myInterval1)
            mySequence.append(myInterval3)
            mySequence.start()
            mySequence2 = Sequence(myInterval2)
            mySequence2.start()
            self.inRoom = "C"
        def moveToRoomD():
            myInterval1 = self.camera.posInterval(1.0, Point3(-20.0, 3.40, 0))
            myInterval2 = self.camera.hprInterval(2.0, Vec3(0, 0, 0))
            myInterval3 = self.camera.posInterval(4.0, Point3(-20.0, 40, 0))
            mySequence = Sequence()
            if self.inRoom:
                mySequence.append(goBackToHall())
            mySequence.append(myInterval1)
            mySequence.append(myInterval3)
            mySequence.start()
            mySequence2 = Sequence(myInterval2)
            mySequence2.start()
            self.inRoom = "D"
        def moveToRoomE():
            myInterval1 = self.camera.posInterval(1.0, Point3(-75.0, 3.40, 0))
            myInterval2 = self.camera.hprInterval(2.0, Vec3(0, 0, 0))
            myInterval3 = self.camera.posInterval(4.0, Point3(-75.0, 40, 0))
            mySequence = Sequence()
            if self.inRoom:
                mySequence.append(goBackToHall())
            mySequence.append(myInterval1)
            mySequence.append(myInterval3)
            mySequence.start()
            mySequence2 = Sequence(myInterval2)
            mySequence2.start()
            self.inRoom = "E"
        def printCamCoords(task):
            print(self.camera.getX(),self.camera.getY(),self.camera.getH())
            return task.again
        self.accept('a', moveToRoomA)
        self.accept('b', moveToRoomB)
        self.accept('c', moveToRoomC)
        self.accept('d', moveToRoomD)
        self.accept('e', moveToRoomE)
        #self.taskMgr.add(printCamCoords, "printCoords")

# create an object for the game and run it
game = MyGame()
game.run()