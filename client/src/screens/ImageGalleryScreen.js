import React, {useEffect, useState} from 'react';
import {View, Image, StyleSheet, FlatList, Text, Button} from 'react-native';
import axios from 'axios';


const ImageGalleryScreen = () => {
  const [images, setImage] = useState([]);

  useEffect(() => {
    getImages()
  }, []);

  return (
    <View style={styles.container}>
      <FlatList
        data={images}
        extraData={images}
        numColumns={3}
        renderItem={({item}) => (
          <View style={styles.imageContainer}>
            <Image style={styles.image} source={{uri: item.Uri}} />
          </View>
        )}
        keyExtractor={(item, index) => index.toString()}
      />

      <Button
        title="Add Image"
        onPress={() => addImage()}
      />
    </View>
  );

  async function getImages(){
    try {
      const response = await axios.get('http://gadaharon-001-site1.gtempurl.com/api/Images')
      setImage(response.data);      
      } catch (error) {
        console.log(error);
      }
  }

  async function addImage() {
    setImage([
      ...images,
      {
        Uri:
          'https://www.humanesociety.org/sites/default/files/styles/768x326/public/2018/08/kitten-440379.jpg?h=f6a7b1af&itok=vU0J0uZR',
      },
    ])
  }
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
  },
  imageContainer: {
    margin: 10
  },
  image: {
    height: 100,
    width: 100,
  },
});

export default ImageGalleryScreen;
