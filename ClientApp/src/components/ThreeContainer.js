import React, { Component } from 'react';
import * as THREE from 'three';
import { GLTFLoader } from 'three/examples/jsm/loaders/GLTFLoader.js';
import { OrbitControls } from 'three/examples/jsm/controls/OrbitControls.js';
import './ThreeContainer.css';
import * as url from '../threejs/assets/MapModels/usa_map_-_low_poly/scene.glb';

class ThreeContainer extends Component {

  componentDidMount() {
    console.log(url);
    
    var scene = new THREE.Scene();
    window.scene = scene;

    const fov = 45;
    const aspect = 2;  // the canvas default
    const near = 0.1;
    const far = 10000;
    const camera = new THREE.PerspectiveCamera(fov, aspect, near, far);
    camera.position.set(0, 10, 20);

    const loader = new GLTFLoader();
    loader.load( url, ( gltf ) => {   
      scene.add(gltf.scene);
      console.log("loaded");
      },
      ( xhr ) => {
        // called while loading is progressing
        console.log( `${( xhr.loaded / xhr.total * 100 )}% loaded` );
        console.log("loading");
        
      },
      ( error ) => {
        // called when loading has errors
        console.error( 'An error happened', error );
        console.log("error");
        
      },
    );

    var renderer = new THREE.WebGLRenderer({ alpha: false });
    renderer.setSize( window.innerWidth, window.innerHeight );
    document.body.appendChild( renderer.domElement );
    
    const controls = new OrbitControls(camera, renderer.domElement)
    controls.enableDamping = true
    controls.dampingFactor = 0.25
    controls.enableZoom = false
    controls.update();

    scene.background = new THREE.Color( 'aquamarine' );
    scene.overrideMaterial = new THREE.MeshBasicMaterial( { color: 'grey' } );
    camera.far = 100000;
    camera.updateProjectionMatrix();
    camera.position.z = 10;


    renderer.render( scene, camera );
  }

  render() {
    return( 
      <div />
    )
  }
}
export default ThreeContainer