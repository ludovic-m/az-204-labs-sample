# Geo Spacial Query with Cosmos DB

- Import Volcano data into a container
- Add a geospacial index

```json
"spatialIndexes": [
        {
            "path": "/Location/*",
            "types": [
                "Point",
                "LineString",
                "Polygon",
                "MultiPolygon"
            ]
        }
    ]
```

- Query with geospacial filters

```sql
SELECT f
FROM Volcanos f
WHERE ST_DISTANCE(f.Location, {"type": "Point", "coordinates":[131.6, 34.5]}) < 30000
```
