import React, { Component } from 'react';
import * as THREE from 'three';
import {GLTFLoader} from 'three/examples/jsm/loaders/GLTFLoader';
import { OrbitControls } from 'three/examples/jsm/controls/OrbitControls.js';
import './ThreeContainer.css';
import * as url from '../assets/MapModels/usa_map_-_low_poly/scene.glb';



class ThreeContainer extends Component {
    componentDidMount(){
      
      const width = window.innerWidth;
      const height = window.innerHeight;
      //ADD SCENE
      this.scene = new THREE.Scene()
      //ADD CAMERA
      this.camera = new THREE.PerspectiveCamera(
        90,
        width / height,
        0.1,
        1000
      )
      this.camera.position.x = 0;
      this.camera.position.y = 3;
      this.camera.position.z = 4;
      //ADD RENDERER
      this.renderer = new THREE.WebGLRenderer({ antialias: true })
      this.renderer.setClearColor('aquamarine')
      this.renderer.setSize(width, height)
      this.renderer.gammaOutput = true;
      this.renderer.gammaFactor = 2.2;
      this.mount.appendChild(this.renderer.domElement)

      //LIGHTNING
      //first point light
      this.light = new THREE.PointLight(0xffffff, 1, 4000);
      this.light.position.set(50, 0, 0);
      //the second one
      this.light_two = new THREE.PointLight(0xffffff, 1, 4000);
      this.light_two.position.set(-100, 800, 800);
      //And another global lightning some sort of cripple GL
      this.lightAmbient = new THREE.AmbientLight(0x404040);
      this.scene.add(this.light, this.light_two, this.lightAmbient);
    
      //ADD CUBE
      // const geometry = new THREE.BoxGeometry(1, 1, 1)
      // const material = new THREE.MeshBasicMaterial({ color: 'pink' })
      // this.cube = new THREE.Mesh(geometry, material)
      // this.scene.add(this.cube)


      // ADD MODEL  
      var loader = new GLTFLoader();
      loader.load(url, ( gltf ) => {
        console.log(gltf);
        
        
        const root = gltf.scene;

        this.scene.add(root);
      });

      // ADD ORBIT CONTROLLS
      this.controls = new OrbitControls(this.camera, this.renderer.domElement);
      // Not used or not needed? -------------->
      // function initializeOrbits() {
      //   this.controls.rotateSpeed = 1.0;
      //   this.controls.zoomSpeed = 1.2;
      //   this.controls.panSpeed = 0.8;
      // }
      // -------------------------------------->
  this.start()
    }
  componentWillUnmount(){
      this.stop()
      this.mount.removeChild(this.renderer.domElement)
    }
  start = () => {
      if (!this.frameId) {
        this.frameId = requestAnimationFrame(this.animate)
      }
    }
  stop = () => {
      cancelAnimationFrame(this.frameId)
    }
  animate = () => {
     this.renderScene()
     this.frameId = window.requestAnimationFrame(this.animate)
   }
  renderScene = () => {
    this.renderer.render(this.scene, this.camera)
  }
  render(){
      return(
        <div
          style={{ width: '100%', height: '100%' }}
          ref={(mount) => { this.mount = mount }}
        />
      )
    }
  }
export default ThreeContainer