﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class StringStringDictionary : SerializableDictionary<string, string> {}

[Serializable]
public class ObjectColorDictionary : SerializableDictionary<UnityEngine.Object, Color> {}

[Serializable]
public class ColorArrayStorage : SerializableDictionary.Storage<Color[]> {}

[Serializable]
public class StringColorArrayDictionary : SerializableDictionary<string, Color[], ColorArrayStorage> {}


[Serializable]
public class StringIntDict : SerializableDictionary<string, int> { }

[Serializable]
public class stringGoDictionary: SerializableDictionary<string, GameObject> { }


#if NET_4_6 || NET_STANDARD_2_0
[Serializable]
public class StringHashSet : SerializableHashSet<string> {}
#endif
