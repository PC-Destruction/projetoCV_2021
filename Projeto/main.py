import random

from panda3d.core import loadPrcFile
from panda3d.core import *
from panda3d.core import Material
loadPrcFile("config.prc")
import introcs
from direct.showbase.ShowBase import ShowBase
from direct.interval.LerpInterval import LerpPosInterval
from direct.task import Task
import os, sys
import math

class MyGame(ShowBase):

    def __init__(self):
        ShowBase.__init__(self)

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
        alight.setColor((0.1, 0.1, 0.1, 0.2))
        alnp = self.render.attachNewNode(alight)
        self.render.setLight(alnp)

        plight = PointLight('plight')
        plight.setColor((1, 1, 1, 0.1))
        plnp = self.render.attachNewNode(plight)
        plnp.setPos(10, 20, 0)
        self.render.setLight(plnp)

        #self.render.setShaderAuto()

        self.disableMouse()
        
        self.useDrive()
        self.useTrackball()
        #self.camera.setPos(19.28, 3.40, 0)

        def printCamCoords(task):
            print(self.camera.getX(),self.camera.getY(),self.camera.getH())
            return task.again

        self.taskMgr.add(printCamCoords, "printCoords")

# create an object for the game and run it
game = MyGame()
game.run()