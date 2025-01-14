__version__= "1.0.0"

import engine

def main():
    path = engine.get_path()
    engine.process(path)   

if __name__ == '__main__':           
    main()