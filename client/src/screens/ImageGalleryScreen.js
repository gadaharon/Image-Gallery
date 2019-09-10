import axios from 'axios';
import React, {useEffect, useState} from 'react';
import {FlatList, Image, StyleSheet, View, ActivityIndicator } from 'react-native';
import Button from '../components/Button';
import Camera from 'react-native-image-crop-picker';

const cameraConfig = {
  includeBase64: true,
  compressImageMaxWidth: 400,
  compressImageMaxHeight: 400,
  compressImageQuality: 0.8,
  mediaType: 'photo',
};

const ImageGalleryScreen = () => {
  const [images, setImage] = useState([]);
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    // Get all images when screen loaded
    getImages();
  }, []);

  const Item = ({item}) => {
    return (
      <View style={styles.imageContainer}>
        <Image style={styles.image} source={{uri: item.Uri}} />
      </View>
    );
  };

  return (
    <View style={styles.container}>
      {isLoading && <ActivityIndicator />}
      <FlatList
        data={images}
        extraData={images}
        numColumns={3}
        renderItem={({item}) => <Item item={item} />}
        keyExtractor={(item, index) => item.ImageId}
      />
      <Button title="הוסף תמונה" onPress={addImage} />
    </View>
  );

  // Get all images
  async function getImages() {
    try {
      const response = await axios.get(
        'http://gadaharon-001-site1.gtempurl.com/api/Images',
      );
      setImage(response.data);
      setIsLoading(false);
    } catch (error) {
      console.log(error);
    }
  }

  // Create new image
  async function addImage() {
    try {
      const image = await Camera.openCamera(cameraConfig);
      const data = {Base64: `data:${image.mime};base64,${image.data}`};
      try {
        setIsLoading(true);
        const response = await axios.post(
          'http://gadaharon-001-site1.gtempurl.com/api/Images',
          data,
        );
        setImage([...images, response.data]);
        setIsLoading(false);
      } catch (error) {
        console.log(error);
        setIsLoading(false);
      }
    } catch (error) {
      console.log(error);
    }
  }
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
  },
  imageContainer: {
    margin: 15
  },
  image: {
    height: 100,
    width: 100,
  },
  addImage: {
    margin: 10,
    borderRadius: 15,
  },
});

export default ImageGalleryScreen;
