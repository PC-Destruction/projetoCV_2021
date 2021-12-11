import random

from panda3d.core import loadPrcFile
from panda3d.core import *
from panda3d.core import Material
loadPrcFile("config.prc")
from direct.showbase.ShowBase import ShowBase
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
        self.setBackgroundColor(0.5,0.5,0)

        self.mapModel = self.loader.loadModel(self.mydir + "/Models/Map/MapModel.bam")
        self.mapModel.setPos(0, 0, 0)
        self.mapModel.setScale(1.5,1.5,1.5)
        myMaterial = Material()
        myMaterial.setShininess(5.0) # Make this material shiny
        myMaterial.setAmbient((0, 0, 1, 1)) # Make this material blue
        self.mapModel.setMaterial(myMaterial)

        self.mapModel.reparentTo(self.render)

        self.disableMouse()
        self.camera.setPos(0, -30, -1)



# create an object for the game and run it
game = MyGame()
game.run()