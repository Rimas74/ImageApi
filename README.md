# ImageApi

A simple API for uploading and retrieving images, converting image to thumbnail, retreaving thumbnail.

## API Endpoints
- **Upload an Image** (`POST /api/images/upload`): Form-data with `FileName` (string) and `File` (file).
- **Get an Image** (`GET /api/images/{id}`): Retrieve an image by its unique ID.
- **Get a Thumbnail** (`GET /api/images/thumbnail/{id}`): Retrieve a thumbnail of the image.

