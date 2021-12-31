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

from Room import Room
from RoomA import RoomA
from RoomB import RoomB
from RoomC import RoomC
from RoomD import RoomD
from RoomE import RoomE

class MyGame(ShowBase):

    def __init__(self):
        ShowBase.__init__(self)
        self.Room = None
        # Get the location of the 'py' file I'm running:
        self.mydir = os.path.abspath(sys.path[0])
        # convert to panda's specific notation
        self.mydir = Filename.fromOsSpecific(self.mydir).getFullpath()
        self.setBackgroundColor(0,0,0)

        self.mapModel = self.loader.loadModel(self.mydir + "/Models/Map/MapModel.bam")
        self.mapModel.setPos(0, 0, 0)
        self.mapModel.setScale(20.0,20.0,20.0)
        mapTexture = self.loader.loadTexture("Models/Map/Texture.jpg")
        self.mapModel.setTexture(mapTexture,1)
        self.mapModel.reparentTo(self.render)

        alight = AmbientLight('alight')
        alight.setColor((1,1,1,1))
        alnp = self.render.attachNewNode(alight)
        self.render.setLight(alnp)

        """plight = PointLight('plight')
        plight.setColor((1, 1,1, 1))
        #plight.setAttenuation(LVecBase3(1,0,0))
        plnp = self.render.attachNewNode(plight)
        plnp.setPos(-5.0, 3.40, 0)
        self.render.setLight(plnp)"""

        

        #self.render.setShaderAuto()

        self.disableMouse()
        
        self.useDrive()
        self.useTrackball()
        self.camLens.set_fov(100)
        self.camera.setPos(19.28, 3.40, 0)
        self.camera.setH(89)

        self.box = self.loader.loadModel("models/box")
        self.box.setPos(-40, 0, 18)
        self.box.reparentTo(self.render)
        
        sptLight = Spotlight("spot")
        sptLens = PerspectiveLens()
        sptLight.setLens(sptLens)
        sptLight.setColor(Vec4(1.0, 0.0, 0.0, 1.0))
        sptLight.setShadowCaster(True)
        sptNode = self.render.attachNewNode(sptLight)
        #sptNode.setPos(25, 3.40, 0.5)
        #sptNode.lookAt(self.camera)
        sptNode.setPos(0, 0, 18)
        sptNode.setHpr(90,-20,0)
        self.render.setLight(sptNode)

        sptLight2 = Spotlight("spot")
        sptLight2.setLens(sptLens)
        sptLight2.setColor(Vec4(0.0, 1.0, 0.0, 1.0))
        sptLight2.setShadowCaster(True)
        sptNode2 = self.render.attachNewNode(sptLight2)
        #sptNode.setPos(25, 3.40, 0.5)
        #sptNode.lookAt(self.camera)
        sptNode2.setPos(-40, 0, 18)
        sptNode2.setHpr(-90,0,0)
        self.render.setLight(sptNode2)

        def goBackToHall():
            if self.Room:
                self.Room.Stop()
                self.Room = None
                return self.camera.posInterval(1.0, Point3(self.camera.getX(), 3.40, 0))
            return None 
        def moveToRoomA():
            myInterval1 = self.camera.posInterval(1.0, Point3(-5.0, 3.40, 0))
            myInterval2 = self.camera.hprInterval(2.0, Vec3(180, 0, 0))
            myInterval3 = self.camera.posInterval(2.0, Point3(-5.0, -60, 0))
            mySequence = Sequence()
            if self.Room:
                mySequence.append(goBackToHall())
            mySequence.append(myInterval1)
            mySequence.append(myInterval3)
            mySequence.start()
            mySequence2 = Sequence(myInterval2)
            mySequence2.start()
            self.Room = RoomA(self)
            self.Room.Start()
        def moveToRoomB():
            myInterval1 = self.camera.posInterval(1.0, Point3(-55.0, 3.40, 0))
            myInterval2 = self.camera.hprInterval(2.0, Vec3(180, 0, 0))
            myInterval3 = self.camera.posInterval(2.0, Point3(-55.0, -60, 0))
            mySequence = Sequence()
            if self.Room:
                mySequence.append(goBackToHall())
            mySequence.append(myInterval1)
            mySequence.append(myInterval3)
            mySequence.start()
            mySequence2 = Sequence(myInterval2)
            mySequence2.start()
            self.Room = RoomB(self)
            self.Room.Start()
        def moveToRoomC():
            myInterval1 = self.camera.posInterval(1.0, Point3(-109.0, 3.40, 0))
            myInterval2 = self.camera.hprInterval(2.0, Vec3(180, 0, 0))
            myInterval3 = self.camera.posInterval(2.0, Point3(-109.0, -60, 0))
            mySequence = Sequence()
            if self.Room:
                mySequence.append(goBackToHall())
            mySequence.append(myInterval1)
            mySequence.append(myInterval3)
            mySequence.start()
            mySequence2 = Sequence(myInterval2)
            mySequence2.start()
            self.Room = RoomC(self)
            self.Room.Start()
        def moveToRoomD():
            myInterval1 = self.camera.posInterval(1.0, Point3(-30.0, 3.40, 0))
            myInterval2 = self.camera.hprInterval(2.0, Vec3(0, 0, 0))
            myInterval3 = self.camera.posInterval(2.0, Point3(-30.0, 53, 0))
            mySequence = Sequence()
            if self.Room:
                mySequence.append(goBackToHall())
            mySequence.append(myInterval1)
            mySequence.append(myInterval3)
            mySequence.start()
            mySequence2 = Sequence(myInterval2)
            mySequence2.start()
            self.Room = RoomD(self)
            self.Room.Start()
        def moveToRoomE():
            myInterval1 = self.camera.posInterval(1.0, Point3(-90.0, 3.40, 0))
            myInterval2 = self.camera.hprInterval(2.0, Vec3(0, 0, 0))
            myInterval3 = self.camera.posInterval(2.0, Point3(-90.0, 53, 0))
            mySequence = Sequence()
            if self.Room:
                mySequence.append(goBackToHall())
            mySequence.append(myInterval1)
            mySequence.append(myInterval3)
            mySequence.start()
            mySequence2 = Sequence(myInterval2)
            mySequence2.start()
            self.Room = RoomE(self)
            self.Room.Start()
        def moveToRoomL():
            if self.Room:
                mySequence = Sequence()
                #19.28, 3.40, 0
                mySequence.append(goBackToHall())
                myInterval1 = self.camera.posInterval(2.0, Point3(19.28, 3.40, 0))
                mySequence.append(myInterval1)
                mySequence.start()
                myInterval2 = self.camera.hprInterval(1.0, Vec3(90.0, 0, 0))
                mySequence2 = Sequence(myInterval2)
                mySequence2.start()
        def printCamCoords(task):
            print(self.camera.getX(),self.camera.getY(),self.camera.getH())
            return task.again
        self.accept('a', moveToRoomA)
        self.accept('b', moveToRoomB)
        self.accept('c', moveToRoomC)
        self.accept('d', moveToRoomD)
        self.accept('e', moveToRoomE)
        self.accept('l', moveToRoomL)
        #self.taskMgr.add(printCamCoords, "printCoords")

# create an object for the game and run it
game = MyGame()
game.run()