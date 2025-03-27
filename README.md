# SnappyMobChallenge
## Programming Challenge - SnappyMobChallenge

# 1 - Challenge A
*Write a program that will generate four (4) types of printable random objects and store them in a single file, each object will be separated by a ",". These are the 4 objects: alphabetical strings, real numbers, integers, alphanumerics. The alphanumerics should contain a random number of spaces before and after it (not exceeding 10 spaces). The output should be 10MB in size.*

ChallengeA is a C# Class Library designed to print four types of random objects in text file as an input,
- **Alphabetical Strings** (Alphabet only)
- **Real Numbers**  (with deciamal points)
- **Integers**  (without decimal points)
- **Alphanumeric Strings** (Combination of Alphabet and numbers with random spaces before and after)  

### ChallengeA Steps:
 1. Each Printable random object classes implement the `IPrintableObject` interface.
 2. Every printable object has its own unique implementation with method GetValue() method.
 3. The PrintableObjects class processes each object randomly using Random.Next().
 4. using StringBuilder, Combined all Text as expected and pass the content to save file method.
 5. The printed objects are stored in a text file and separated by commas **(,)** and also with a total output size of **10MB**.
 6. Final output stored as input in app/data/input folder.

# 2 - Challenge B
  *Create a program that will read the generated file above and print to the console the object and its type. Spaces before and after the alphanumeric object must be stripped.*
  
  ChallengeB is a C# console application designed to read and extract the four types of random objects and identify the type of each objects.
  ### ChallengeB Steps:
  1. ChallengeB serves as the entry point for this solution.
  2. It reads the content from ChallengeA's output and processes each printable object.
  3. The content is split using (,) and each object is iterated one by one.
  4. spaces in before and after are removed using Trim().
  5. Each printable object's type is validated using validation methods.
  6. The processed objects are printed to a text file and formatted line by line with a maximum file size of 10MB.
  7. The final output is stored in the app/data/output folder.
       
# 3 - Challenge C
  *Dockerize Challenge B. Write a docker file so that it reads the output from Challenge A as an Input. Once this container is started, the program in challenge B is executed to process this file. The output 
  should be saved in a file and should be exposed to the Docker host machine.*
  ### ChallengeC Steps:
  1. Build docker image for ChallengeB with version with help of dockerfile.

     docker build -t challengeb:dev .
     
  3. Create and Run container with challengb:dev docker image and mounting a directory from the host machine to the container to enable data sync between them. (CLI interactive)

     docker run -it --name challengeb -v //c/logs:/app/data challengeb:dev /bin/bash
     
  
  or
  
  3. Start or execute the services based on the docker-compose.yml file which contains docker image, container and volume to mount the host to container. (background service)

     docker-compose up -d
     
  The output saved in the container directory will immediately reflect on the Docker host machine when the challengeb program runs.
  
  
  *For more implementation details, please refer to the program.*


        


        
