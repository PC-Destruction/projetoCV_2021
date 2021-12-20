from Room import Room
from direct.interval.IntervalGlobal import *
from panda3d.core import CardMaker
from panda3d.core import *

class RoomA(Room):
    def __init__(self,prog) -> None:
        super().__init__()
        self.prog = prog
    def Start(self):
        self.thatcherEffect()
    def Stop(self):
        self.moldura.removeNode()

    def thatcherEffect(self):
        self.moldura = self.prog.render.attachNewNode('root')
        self.molduraRoomA = self.prog.loader.loadModel("models/box")
        
        self.molduraRoomA.setScale(20.0,20.0,20.0)
        self.molduraRoomA.reparentTo(self.moldura)
        center = self.molduraRoomA.getBounds().getCenter()
        self.molduraRoomA.setPos(-center.getX(), 0, -center.getZ())
        self.moldura.setPos(-5.0, -110, 0)

        molduraTexture = self.prog.loader.loadTexture("Resources/RoomA/thatcher-effect.jpg")
        self.molduraRoomA.setTexture(molduraTexture,1)
        LerpHprInterval(self.moldura, 2, Point3(0, 0, 180)).start()