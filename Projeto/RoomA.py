from Room import Room
from direct.interval.IntervalGlobal import *
from panda3d.core import CardMaker
from panda3d.core import *

class RoomA(Room):
    def __init__(self,prog) -> None:
        super().__init__()
        self.prog = prog
        self.action = None
    def Start(self):
        #self.thatcherEffect()
        self.prog.accept('1', self.thatcherEffect)
        self.prog.accept('2', self.colorPerception)
    def Stop(self):
        self.moldura.removeNode()

    def thatcherEffect(self):
        if self.action != "thatcherEffect":
            self.action = "thatcherEffect"
            self.moldura = self.prog.render.attachNewNode('root')
            self.molduraRoomA = self.prog.loader.loadModel("models/box")
            
            self.molduraRoomA.setScale(20.0,20.0,20.0)
            self.molduraRoomA.reparentTo(self.moldura)
            center = self.molduraRoomA.getBounds().getCenter()
            self.molduraRoomA.setPos(-center.getX(), 0, -center.getZ())
            self.moldura.setPos(-5.0, -110, 0)

            molduraTexture = self.prog.loader.loadTexture("Resources/RoomA/thatcher-effect.jpg")
            self.molduraRoomA.setTexture(molduraTexture,1)
        else:
            LerpHprInterval(self.moldura, 2, Point3(0, 0, 180)).start()
    
    def colorPerception(self):
        if self.action != "colorPerception":
            self.action = "colorPerception"
            plight = PointLight('plight')
            plight.setColor((0.8, 0.5, 0.5, 1))
            plight.setAttenuation(LVecBase3(1,0,0))
            plnp = self.prog.render.attachNewNode(plight)
            plnp.setPos(-5.0, -60, 0)
            self.prog.render.setLight(plnp)